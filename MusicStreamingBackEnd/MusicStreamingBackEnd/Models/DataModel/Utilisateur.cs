using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicStreamingBackEnd.Models
{
    public class Utilisateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Email { get; set; }
        public string surnomArtiste { get; set; }
        public string Password { get; set; }//ajouter albums,et musique 
        public string photoProfil { get; set; }
        public virtual List<Album> albums { get; set; }
    }
}