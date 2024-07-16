using System;

namespace Vispl.Trainee.CricInfo.ViewScheduledMatches.VO
{
    public class clsTournamentVO
    {
        public int TournamentID { get; set; }
        public string TournamentName { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int MatchTypeId { get; set; }
        public int MatchType { get; set; }
    }
}
