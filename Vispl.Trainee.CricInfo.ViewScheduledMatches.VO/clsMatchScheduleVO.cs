using System;
using System.Collections.Generic;

namespace Vispl.Trainee.CricInfo.ViewScheduledMatches.VO
{
    public class clsMatchScheduleVO
    {
        public int ID { get; set; }
        public string FirstTeam { get; set; }
        public string SecondTeam { get; set; }

        public DateTime ScheduledTime { get; set; }

        public string Venue { get; set; }

        public int TournamentID { get; set; }

        public string TournamentName { get; set; }

        public List<clsTeamsVO> Teams { get; set; }
    }
}
