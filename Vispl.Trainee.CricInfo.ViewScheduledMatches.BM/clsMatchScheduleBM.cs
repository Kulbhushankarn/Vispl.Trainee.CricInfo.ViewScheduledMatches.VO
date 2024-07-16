using System.Collections.Generic;
using Vispl.Trainee.CricInfo.DI;
using Vispl.Trainee.CricInfo.ViewScheduledMatches.DL.ITF;
using Vispl.Trainee.CricInfo.ViewScheduledMatches.BM.ITF;
using Vispl.Trainee.CricInfo.ViewScheduledMatches.VO;
using Vispl.Trainee.CricInfo.DLContainer;

namespace Vispl.Trainee.CricInfo.ViewScheduledMatches.BM
{
    public class clsMatchScheduleBM : IclsMatchScheduleBM
    {
        public IclsMatchScheduleDL DlObj { get; set; }

        public List<clsMatchScheduleVO> GetAllMatchSchedules()
        {
            //DlObj = (IclsMatchScheduleDL)GetDlInstance.getObject("Vispl.Trainee.CricInfo.ViewScheduledMatches.DL.clsMatchScheduleDL");
            DlObj = clsCricInfoDI.GetObject<IclsMatchScheduleDL>("Vispl.Trainee.CricInfo.ViewScheduledMatches.DL.clsMatchScheduleDL");
            return DlObj.GetAllMatchSchedulesWithNames();
        }

        public List<clsMatchScheduleVO> GetMatchesByTournament(int tournamentID)
        {
            DlObj = clsCricInfoDI.GetObject<IclsMatchScheduleDL>("Vispl.Trainee.CricInfo.ViewScheduledMatches.DL.clsViewTournamentDL");
            return DlObj.GetMatchesByTournament(tournamentID);
        }

        public List<KeyValuePair<int, string>> GetTeams()
        {
            DlObj = clsCricInfoDI.GetObject<IclsMatchScheduleDL>("Vispl.Trainee.CricInfo.ViewScheduledMatches.DL.clsMatchScheduleDL");
            return DlObj.GetTeams();
        }
    }
}
