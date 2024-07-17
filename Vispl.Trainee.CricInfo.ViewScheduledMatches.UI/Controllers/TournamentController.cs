// TournamentController.cs

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Vispl.Trainee.CricInfo.DI;
using Vispl.Trainee.CricInfo.ViewScheduledMatches.VO;
using Vispl.Trainee.CricInfo.ViewScheduledMatches.BM.ITF;

namespace Vispl.Trainee.CricInfo.ViewScheduledMatches.UI.Controllers
{
    public class TournamentController : Controller
    {
        public IclsTournamentBM bmObj { get; set; }

        public TournamentController()
        {
            bmObj = clsCricInfoDI.GetObject<IclsTournamentBM>("Vispl.Trainee.CricInfo.ViewScheduledMatches.BM.clsTournamentBM");
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

        public ActionResult GetMatchesByTournament(int tournamentID)
        {
            try
            {
                List<clsMatchScheduleVO> matches = bmObj.GetMatchesByTournament(tournamentID);
                return Json(matches, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = "Error retrieving matches: " + ex.Message });
            }
        }
    }

}
