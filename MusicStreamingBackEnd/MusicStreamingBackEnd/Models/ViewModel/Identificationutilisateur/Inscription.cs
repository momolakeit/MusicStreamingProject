using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStreamingBackEnd.Models.ViewModel
{
    public class Inscription
    {
        [Key]
        public int id { get; set; }
        public string Email { get; set; }
        public string surnomArtiste { get; set; }
        public string Password { get; set; }
        public string PhotoProfil { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}