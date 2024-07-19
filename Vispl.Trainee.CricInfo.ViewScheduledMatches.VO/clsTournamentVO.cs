using System;
using System.Collections.Generic;

namespace Vispl.Trainee.CricInfo.ViewScheduledMatches.VO
{
    public class clsTournamentVO
    {
        public int TournamentID { get; set; }
        public string TournamentName { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int MatchTypeId { get; set; }
        public string MatchType { get; set; }
        public List<clsMatchScheduleVO> Teams { get; set; }
/*        public List<clsTeamsVO> TeamsName { get; set; }*/
        public string FirstTeam { get; set; }
        public string SecondTeam { get; set; }
    }
}
