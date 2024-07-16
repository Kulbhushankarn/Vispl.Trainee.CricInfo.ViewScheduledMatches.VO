using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vispl.Trainee.CricInfo.DI;
using Vispl.Trainee.CricInfo.ViewScheduledMatches.VO;
using Vispl.Trainee.CricInfo.ViewScheduledMatches.BM.ITF;

namespace Vispl.Trainee.CricInfo.ViewScheduledMatches.UI.Controllers
{
    public class TournamentController : Controller
    {
        public IclsMatchScheduleBM BmObj { get; set; }
        public IclsTournamentBM bmObj { get; set; }
        public TournamentController()
        {
            BmObj = clsCricInfoDI.GetObject<IclsMatchScheduleBM>("Vispl.Trainee.CricInfo.ViewMatchSchdule.BM.clsMatchScheduleBM");
            bmObj = clsCricInfoDI.GetObject<IclsTournamentBM>("Vispl.Trainee.CricInfo.ViewMatchSchdule.BM.clsTournamentBM");
        }
        public ActionResult DisplayTournamentDataInGrid()
        {
            List<clsTournamentVO> tournaments;
            try
            {
                tournaments = bmObj.GetAllTournaments();
            }
            catch (Exception ex)
            {
                tournaments = new List<clsTournamentVO>();
                ModelState.AddModelError("", "Error retrieving tournaments: " + ex.Message);
            }

            return View(tournaments);
        }

        //public ActionResult GetMatchesByTournament(int tournamentID)
        //{
        //    List<clsMatchScheduleVO> matches;
        //    try
        //    {
        //        matches = bmObj.GetMatchesByTournament(tournamentID);
        //    }
        //    catch (Exception ex)
        //    {
        //        matches = new List<clsMatchScheduleVO>();
        //        ModelState.AddModelError("", "Error retrieving matches: " + ex.Message);
        //    }

        //    return Json(matches, JsonRequestBehavior.AllowGet);
        //}
    }
}