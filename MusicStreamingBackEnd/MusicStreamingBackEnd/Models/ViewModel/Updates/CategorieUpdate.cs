using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStreamingBackEnd.Models.ViewModel
{
    public class CategorieUpdate
    {
        [Key]
        public int id { get; set; }
        public string nom { get; set; }
    }
}