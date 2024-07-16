using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Vispl.Trainee.CricInfo.DI;
using Vispl.Trainee.CricInfo.ViewScheduledMatches.BM.ITF;
using Vispl.Trainee.CricInfo.ViewScheduledMatches.VO;
using Vispl.Trainee.CricInfo.BMContainer;

namespace Vispl.Trainee.CricInfo.ViewScheduledMatches.UI.Controllers
{
    public class MatchScheduleController : Controller
    {
        public IclsMatchScheduleBM BmObj { get; set; }        

        private void PopulateViewBags()
        {
           // BmObj = (IclsMatchScheduleBM)GetBmInstance.getObject("Vispl.Trainee.CricInfo.ViewScheduledMatches.BM.clsMatchScheduleBM");
           BmObj = clsCricInfoDI.GetObject<IclsMatchScheduleBM>("Vispl.Trainee.CricInfo.ViewScheduledMatches.BM.clsMatchScheduleBM");
            ViewBag.Teams = BmObj.GetTeams();
        }

        public ActionResult DisplayMatchDataInGrid()
        {
            BmObj = clsCricInfoDI.GetObject<IclsMatchScheduleBM>("Vispl.Trainee.CricInfo.ViewScheduledMatches.BM.clsMatchScheduleBM");
            List<clsMatchScheduleVO> matchSchedules;
            try
            {
                matchSchedules = BmObj.GetAllMatchSchedules();
            }
            catch (Exception ex)
            {
                matchSchedules = new List<clsMatchScheduleVO>();
                ModelState.AddModelError("", "Error retrieving match schedules: " + ex.Message);
            }

            return View(matchSchedules);
        }
    }
}