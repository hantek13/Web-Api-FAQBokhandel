using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web_Api_FAQBokhandel.Models.ViewModels
{
    public class FaqViewModel
    {
        public int Id { get; set; }

         [Display(Name = "Spørsmål")]
        public string SporsmolText { get; set; }
        
        [Display(Name = "Svar")]
        public string SvarText { get; set; }
        public int KatagoriId { get; set; }
    }
}