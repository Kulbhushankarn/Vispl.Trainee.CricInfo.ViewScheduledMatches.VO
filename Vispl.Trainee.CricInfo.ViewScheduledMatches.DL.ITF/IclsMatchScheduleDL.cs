using System.Collections.Generic;
using Vispl.Trainee.CricInfo.ViewScheduledMatches.VO;

namespace Vispl.Trainee.CricInfo.ViewScheduledMatches.DL.ITF
{
    public interface IclsMatchScheduleDL
    {
        string connectionString { get; set; }

        List<clsMatchScheduleVO> GetAllMatchSchedulesWithNames();
        void getConnection();
        List<KeyValuePair<int, string>> GetTeams();
    }
}