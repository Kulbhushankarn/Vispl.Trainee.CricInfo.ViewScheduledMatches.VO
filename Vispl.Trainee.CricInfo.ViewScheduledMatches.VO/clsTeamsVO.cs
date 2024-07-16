using System.ComponentModel.DataAnnotations;

namespace Vispl.Trainee.CricInfo.ViewScheduledMatches.VO
{
    public class clsTeamsVO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Team name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Short name is required")]
        public string ShortName { get; set; }
        public byte[] Logo { get; set; }

        [Required(ErrorMessage = "Team Captain is required")]
        public string Captain { get; set; }

        [Required(ErrorMessage = "Team ViceCaptain is required")]
        public string ViceCaptain { get; set; }

        [Required(ErrorMessage = "Team WicketKeeper is required")]
        public string WicketKeeper { get; set; }

        [Required(ErrorMessage = "Team Players is required")]
        public string[] Player { get; set; }
        [Required(ErrorMessage = "Team Players is required")]
        public string[] Substitutes { get; set; }

        [Required(ErrorMessage = "Home Ground is required")]
        public string HomeGround { get; set; }
        public string CountryName { get; set; }
    }
}
