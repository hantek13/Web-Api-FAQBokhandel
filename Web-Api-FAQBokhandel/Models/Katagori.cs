using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Api_FAQBokhandel.Models
{
    public class Katagori
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Bilde { get; set; }
        public virtual List<KundeSporsmol> KundeSporsmol { get; set; }
        public virtual List<FAQ> Faqer { get; set; }

    }
}