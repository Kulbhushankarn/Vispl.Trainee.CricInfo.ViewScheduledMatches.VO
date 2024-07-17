using System.Collections.Generic;
using Vispl.Trainee.CricInfo.ViewScheduledMatches.DL.ITF;
using Vispl.Trainee.CricInfo.ViewScheduledMatches.VO;

namespace Vispl.Trainee.CricInfo.ViewScheduledMatches.BM.ITF
{
    public interface IclsTournamentBM
    {
        IclsViewTournamentDL DlObj { get; set; }

        List<clsTournamentVO> GetAllTournaments();

        List<clsMatchScheduleVO> GetMatchesByTournament(int tournamentID);
    }
}