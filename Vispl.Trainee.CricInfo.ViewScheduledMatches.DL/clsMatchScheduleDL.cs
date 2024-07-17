using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Vispl.Trainee.CricInfo.ViewScheduledMatches.VO;
using Vispl.Trainee.CricInfo.ViewScheduledMatches.DL.ITF;
using Vispl.Trainee.CricInfo.DbStructure; 
using Vispl.Trainee.CricInfo.WayToConnect;


namespace Vispl.Trainee.CricInfo.ViewScheduledMatches.DL
{
    public class clsMatchScheduleDL : IclsMatchScheduleDL
    {
        public string connectionString { get; set; }
        private SqlConnection conn { get; set; }
        private SqlDataAdapter Adapter { get; set; }

        public void getConnection()
        {
            connectionString = clsCricInfoConnectionString.GetConnectionString();
        }

        /// <summary>
        /// This helps to get the data from the data table to display the match schedule view.
        /// </summary>
        public List<clsMatchScheduleVO> GetAllMatchSchedulesWithNames()
        {
            getConnection();
            conn = new SqlConnection(connectionString);

            List<clsMatchScheduleVO> matchSchedules = new List<clsMatchScheduleVO>();
            string sqlQuery =
                               $"SELECT ms.{MatchSchedule.FirstTeam}, " +
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
                               $"INNER JOIN {Tbl.AddTournament} at ON ms.{MatchSchedule.TournamentId} = at.{AddTournament.TournamentID}";
            Adapter = new SqlDataAdapter(sqlQuery, conn);
            DataTable dataTable = new DataTable();
            Adapter.Fill(dataTable);
            Adapter.Dispose();
            Adapter = null;

            foreach (DataRow row in dataTable.Rows)
            {
                DateTimeOffset dateTimeOffset = (DateTimeOffset)row["ScheduledTime"];
                DateTime date = dateTimeOffset.DateTime;
                TimeSpan offset = dateTimeOffset.Offset;
                string sign = offset >= TimeSpan.Zero ? "+" : "-";
                string timeZone = "UTC" + sign + offset.ToString(@"hh\:mm");

                clsMatchScheduleVO matchSchedule = new clsMatchScheduleVO
                {
                    FirstTeam = row["FirstTeamName"].ToString(),
                    SecondTeam = row["SecondTeamName"].ToString(),
                    ScheduledTime = date,
                    Venue = row["Venue"].ToString(),
                    TournamentName = row["TournamentName"].ToString(),
                    TournamentID = Convert.ToInt32(row["TournamentID"]),
                    Teams = new List<clsTeamsVO>
                    {
                        new clsTeamsVO { Name = row["FirstTeamName"].ToString() },
                        new clsTeamsVO { Name = row["SecondTeamName"].ToString() }
                    }
                };
                matchSchedules.Add(matchSchedule);
            }

            return matchSchedules;
        }

        /// <summary>
        /// This helps to get team names to display in the match schedule view.
        /// </summary>
        public List<KeyValuePair<int, string>> GetTeams()
        {
            getConnection();
            conn = new SqlConnection(connectionString);

            List<KeyValuePair<int, string>> teams = new List<KeyValuePair<int, string>>();
            string query = $"SELECT {Team.ID}, {Team.Name} FROM {Tbl.Team}";
            Adapter = new SqlDataAdapter(query, conn);
            DataTable dataTable = new DataTable();
            Adapter.Fill(dataTable);
            Adapter.Dispose();
            Adapter = null;

            foreach (DataRow row in dataTable.Rows)
            {
                teams.Add(new KeyValuePair<int, string>(
                    Convert.ToInt32(row[Team.ID]),
                    row[Team.Name].ToString()
                ));
            }

            return teams;
        }
    }
}
