using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Api_FAQBokhandel.Models.ViewModels
{
    public class KatagoriViewModel
    {

        
        public int Id { get; set; }

        [Display(Name = "Katagori")]
        public string Type { get; set; }
        public string Bilde { get; set; }
        public virtual List<KundeSporsmol> KundeSporsmoler { get; set; }
    }
}