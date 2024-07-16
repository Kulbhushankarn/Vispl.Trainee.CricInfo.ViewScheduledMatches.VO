﻿using System;
using System.Collections.Generic;
using Vispl.Trainee.CricInfo.DI;
using Vispl.Trainee.CricInfo.ViewScheduledMatches.DL.ITF;
using Vispl.Trainee.CricInfo.ViewScheduledMatches.BM.ITF;
using Vispl.Trainee.CricInfo.ViewScheduledMatches.VO;

namespace Vispl.Trainee.CricInfo.ViewScheduledMatches.BM
{
    public class clsTournamentBM : IclsTournamentBM
    {
        public IclsViewTournamentDL DlObj { get; set; }
        public List<clsTournamentVO> GetAllTournaments()
        {
            try
            {
                DlObj = clsCricInfoDI.GetObject<IclsViewTournamentDL>("Vispl.Trainee.CricInfo.DL.clsViewTournamentDL");
                return DlObj.GetTournament();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while fetching tournaments.", ex);
            }
        }


    }
}
