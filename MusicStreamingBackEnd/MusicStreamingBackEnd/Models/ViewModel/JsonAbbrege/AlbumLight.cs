using MusicStreamingBackEnd.Models.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
/// <summary>
/// ////////////////un 
/// </summary>
namespace MusicStreamingBackEnd.Models.ViewModel.JsonAbbrege
{
    public class AlbumLight
    {
        [Key]
        public int id { get; set; }
       
        public int fkUtilisateurId { get; set; }
       
        public int fkCategorieId { get; set; }

        public string nomAlbum { get; set; }

        public string albumPath { get; set; }

        public string albumImgPath { get; set; }

        public virtual List<MusiqueLight> Musiques { get; set; }
       
        public virtual UtilisateurLight Utilisateur { get; set; }
       
        public virtual CategorieLight Categorie { get; set; }
    }
}