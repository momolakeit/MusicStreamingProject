using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStreamingBackEnd.Models.ViewModel
{
    public class UtilisateurUpdate
    {
        [Key]
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string photoProfil { get; set; }
    }
}