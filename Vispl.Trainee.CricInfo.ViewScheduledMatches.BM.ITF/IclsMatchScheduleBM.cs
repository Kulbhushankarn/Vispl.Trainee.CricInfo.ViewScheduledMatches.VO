using System.Collections.Generic;
using Vispl.Trainee.CricInfo.ViewScheduledMatches.DL.ITF;
using Vispl.Trainee.CricInfo.ViewScheduledMatches.VO;

namespace Vispl.Trainee.CricInfo.ViewScheduledMatches.BM.ITF
{
    public interface IclsMatchScheduleBM
    {
        IclsMatchScheduleDL DlObj { get; set; }

        List<clsMatchScheduleVO> GetAllMatchSchedules();
        List<clsMatchScheduleVO> GetMatchesByTournament(int tournamentID);
        List<KeyValuePair<int, string>> GetTeams();
    }
}