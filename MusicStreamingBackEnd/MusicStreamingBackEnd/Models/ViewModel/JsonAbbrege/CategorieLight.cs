using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicStreamingBackEnd.Models.ViewModel.JsonAbbrege
{
    public class CategorieLight
    {
        [Key]
        
        public int id { get; set; }

        public string Nom { get; set; }

        public virtual List<MusiqueLight> Musiques { get; set; }

        public virtual List<AlbumLight> Albums { get; set; }
    }
}