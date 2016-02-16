using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Api_FAQBokhandel.Models
{
    public class Kunde
    {
         [Key]
        public int Id { get; set; }
        public string Navn { get; set; }
      
        public string Email { get; set; }


        public virtual List<KundeSporsmol> KundeSporsmoler { get; set; } 



    }
}