using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelBlog.Models.Siniflar
{
    public class AdresBlog
    {
        [Key]
        public int ID { get; set; }
        public string BASLIK { get; set; }
        public string ACIKLAMA { get; set; }
        public string ADRESACIK { get; set; }
        public string ADRES { get; set; }
        public string TELEFON { get; set; }
        public string KONUM { get; set; }

    }
}