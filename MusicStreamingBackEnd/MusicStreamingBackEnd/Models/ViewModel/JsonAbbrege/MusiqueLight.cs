using MusicStreamingBackEnd.Models.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStreamingBackEnd.Models.ViewModel.JsonAbbrege
{
    public class MusiqueLight
    {
        [Key]
        
        public int id { get; set; }
        
        public int fkCategorieId { get; set; }
        
        public int fkAlbumId { get; set; }

        public string NomMusique { get; set; }

        public string musicPath { get; set; }
            
        public string albumImgPath { get; set; }

        public virtual AlbumLight album { get; set; }
        
        public virtual CategorieLight Categorie { get; set; }
    }
}