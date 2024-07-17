using System.Collections.Generic;
using Vispl.Trainee.CricInfo.ViewScheduledMatches.VO;

namespace Vispl.Trainee.CricInfo.ViewScheduledMatches.DL.ITF
{
    public interface IclsViewTournamentDL
    {
/*        string connectionString { get; set; }

        void getConnection();*/
        List<clsTournamentVO> GetTournament();

        List<clsMatchScheduleVO> GetMatchesByTournament(int tournamentID);
    }
}