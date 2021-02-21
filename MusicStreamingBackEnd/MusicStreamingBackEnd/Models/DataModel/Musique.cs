using MusicStreamingBackEnd.Models.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicStreamingBackEnd.Models
{
    public class Musique
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("Categorie")]
        public int fkCategorieId { get; set; }
        [ForeignKey("album")]
        public int fkAlbumId { get; set; }
        public string NomMusique { get; set; }
        public string musicPath { get; set; }
        [ForeignKey("fkAlbumId")]
        public virtual Album album { get; set; }
        [ForeignKey("fkCategorieId")]
        public virtual Categorie Categorie { get; set; }
    }
}