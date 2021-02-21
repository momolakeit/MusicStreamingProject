using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicStreamingBackEnd.Models.DataModel
{
    public class Categorie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Nom { get; set; }
        public virtual List<Musique> Musiques{ get; set; }
     
        public virtual List<Album> Albums{ get; set; }

    }
}