using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStreamingBackEnd.Models.ViewModel
{
    public class MusiqueUpdate
    {
        [Key]
        public int id { get; set; }
        public string nomMusique { get; set; }
        public string musicPath { get; set; }
    }
}