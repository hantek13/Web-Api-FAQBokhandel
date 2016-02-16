using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web_Api_FAQBokhandel.Models.ViewModels
{
    public class KundeSporsmolViewModel
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression("^[a-zæøåA-ZÆØÅ. \\-]{2,30}$")]
        public string Navn { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

         [Display(Name = "Spørsmål")]
        public string Sporsmoltext { get; set; }
        public int KatagoriId { get; set; }
        public string KatagoriType { get; set; }
        public string Dato { get; set; }
       
    }
}