using MusicStreamingBackEnd.Models.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicStreamingBackEnd.Models
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("Utilisateur")]
        public int fkUtilisateurId { get; set; }
        [ForeignKey("Categorie")]
        public int fkCategorieId { get; set; }
        public string nomAlbum { get; set; }
        public string albumPath { get; set; }
        public string albumImgPath { get; set; }
        public virtual List<Musique> Musiques { get; set; }
        [ForeignKey("fkUtilisateurId")]
        public virtual Utilisateur Utilisateur{ get; set; }
        [ForeignKey("fkCategorieId")]
        public virtual Categorie Categorie{ get; set; }
    }
}