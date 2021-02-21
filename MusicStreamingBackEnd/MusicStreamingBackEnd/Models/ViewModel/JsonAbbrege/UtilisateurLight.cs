using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStreamingBackEnd.Models.ViewModel.JsonAbbrege
{
    public class UtilisateurLight
    {
        [Key]
        
        public int id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string photoProfil { get; set; }

        public string surnomArtiste { get; set; }

        public virtual List<AlbumLight> albums { get; set; }
        public virtual List<MusiqueLight> musiques { get; set; }
    }
}