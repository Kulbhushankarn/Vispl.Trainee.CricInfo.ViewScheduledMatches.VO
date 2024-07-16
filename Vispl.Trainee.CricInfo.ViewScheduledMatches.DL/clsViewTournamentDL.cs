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
        public string connectionString { get; set; }
        private SqlConnection conn { get; set; }
        private SqlDataAdapter Adapter { get; set; }

        public void getConnection()
        {
            connectionString = clsCricInfoConnectionString.GetConnectionString();
        }

        public List<clsTournamentVO> GetTournament()
        {
            getConnection();
            conn = new SqlConnection(connectionString);

            List<clsTournamentVO> TournamentView = new List<clsTournamentVO>();
            string sqlQuery = $@"SELECT 
                                    t.{AddTournament.TournamentID}, 
                                    t.{AddTournament.Name} AS TournamentName, 
                                    t.{AddTournament.StartDate}, 
                                    t.{AddTournament.EndDate}, 
                                    t.{AddTournament.TypeId}, 
                                    tt.{TournamentType.TypeName} 
                                FROM 
                                    {Tbl.AddTournament} t
                                LEFT JOIN 
                                    {Tbl.TournamentType} tt 
                                ON 
                                    t.{AddTournament.TypeId} = tt.{TournamentType.TypeId};";
            Adapter = new SqlDataAdapter(sqlQuery, conn);
            DataTable dataTable = new DataTable();
            Adapter.Fill(dataTable);
            Adapter.Dispose();
            Adapter = null;

            foreach (DataRow row in dataTable.Rows)
            {
                clsTournamentVO tour = new clsTournamentVO
                {
                    TournamentID = Convert.ToInt32(row[AddTournament.TournamentID]),
                    TournamentName = row["TournamentName"].ToString(),
                    StartDate = (DateTimeOffset)row[AddTournament.StartDate],
                    EndDate = (DateTimeOffset)row[AddTournament.EndDate],
                    MatchTypeId = row[AddTournament.TypeId] != DBNull.Value ? Convert.ToInt32(row[AddTournament.TypeId]) : 0,
                    //MatchType = row[TournamentType.TypeName].ToString() // Assuming you want to map TypeName to MatchType
                };

                TournamentView.Add(tour);
            }

            return TournamentView;
        }
    }
}
