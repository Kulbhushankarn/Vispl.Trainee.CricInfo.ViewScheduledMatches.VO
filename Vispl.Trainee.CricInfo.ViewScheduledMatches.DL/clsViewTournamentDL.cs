using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Vispl.Trainee.CricInfo.DbStructure;
using Vispl.Trainee.CricInfo.ViewScheduledMatches.VO;
using Vispl.Trainee.CricInfo.ViewScheduledMatches.DL.ITF;
using Vispl.Trainee.CricInfo.WayToConnect;

namespace Vispl.Trainee.CricInfo.ViewScheduledMatches.DL
{
    public class clsViewTournamentDL : IclsViewTournamentDL
    {
        public string ConnectionString { get; set; }

        public clsViewTournamentDL()
        {
            ConnectionString = clsCricInfoConnectionString.GetConnectionString();
        }

        public List<clsTournamentVO> GetTournament()
        {
            List<clsTournamentVO> tournaments = new List<clsTournamentVO>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string sqlQuery =
                    $"SELECT t.{AddTournament.TournamentID}, " +
                    $"t.{AddTournament.Name} AS TournamentName, " +
                    $"t.{AddTournament.StartDate}, " +
                    $"t.{AddTournament.EndDate}, " +
                    $"t.{AddTournament.TypeId}, " +
                    $"tt.{TournamentType.TypeName} AS MatchType " +
                    $"FROM {Tbl.AddTournament} t " +
                    $"LEFT JOIN {Tbl.TournamentType} tt " +
                    $"ON t.{AddTournament.TypeId} = tt.{TournamentType.TypeId};";

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, conn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        clsTournamentVO tournament = new clsTournamentVO
                        {
                            TournamentID = Convert.ToInt32(row[AddTournament.TournamentID]),
                            TournamentName = row["TournamentName"].ToString(),
                            StartDate = row.Field<DateTimeOffset>(AddTournament.StartDate),
                            EndDate = row.Field<DateTimeOffset>(AddTournament.EndDate),
                            MatchTypeId = row.Field<int?>(AddTournament.TypeId) ?? 0,
                            //MatchType = row["MatchType"].ToString()
                        };

                        tournaments.Add(tournament);
                    }
                }
            }

            return tournaments;
        }

        public List<clsMatchScheduleVO> GetMatchesByTournament(int tournamentID)
        {
            List<clsMatchScheduleVO> matches = new List<clsMatchScheduleVO>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string sqlQuery =
                    $"SELECT " +
                    $"ms.{MatchSchedule.FirstTeam}, " +
                    $"ms.{MatchSchedule.SecondTeam}, " +
                    $"ms.{MatchSchedule.ScheduledTime}, " +
                    $"ms.{MatchSchedule.Venue}, " +
                    $"t1.{Team.Name} AS FirstTeamName, " +
                    $"t2.{Team.Name} AS SecondTeamName, " +
                    $"at.{AddTournament.TournamentID}, " +
                    $"at.{AddTournament.Name} AS TournamentName " +
                    $"FROM {Tbl.MatchSchedule} ms " +
                    $"INNER JOIN {Tbl.Team} t1 ON ms.{MatchSchedule.FirstTeam} = t1.{Team.ID} " +
                    $"INNER JOIN {Tbl.Team} t2 ON ms.{MatchSchedule.SecondTeam} = t2.{Team.ID} " +
                    $"INNER JOIN {Tbl.AddTournament} at " +
                    $"ON ms.{MatchSchedule.TournamentId} = at.{AddTournament.TournamentID} " +
                    $"WHERE ms.{MatchSchedule.TournamentId} = @TournamentID;";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@TournamentID", tournamentID);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DateTimeOffset dateTimeOffset = (DateTimeOffset)reader["ScheduledTime"];
                        DateTime date = dateTimeOffset.DateTime;

                        clsMatchScheduleVO match = new clsMatchScheduleVO
                        {
                            FirstTeam = reader["FirstTeamName"].ToString(),
                            SecondTeam = reader["SecondTeamName"].ToString(),
                            ScheduledTime = date,
                            Venue = reader["Venue"].ToString(),
                            TournamentID = Convert.ToInt32(reader[AddTournament.TournamentID]),
                            TournamentName = reader["TournamentName"].ToString(),
                            Teams = new List<clsTeamsVO>
                            {
                                new clsTeamsVO { Name = reader["FirstTeamName"].ToString() },
                                new clsTeamsVO { Name = reader["SecondTeamName"].ToString() }
                            }
                        };

                        matches.Add(match);
                    }
                }
            }

            return matches;
        }

    }
}
