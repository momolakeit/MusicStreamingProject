using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStreamingBackEnd.Models.ViewModel.JsonAbbrege
{
    public class CategorieName
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}