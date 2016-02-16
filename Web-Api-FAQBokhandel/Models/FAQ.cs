using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web_Api_FAQBokhandel.Models
{
    public class FAQ
    {
        [Key]
        public int Id { get; set; }     
        public string SporsmolText { get; set; }
        public string SvarText { get; set; }
        public virtual Katagori katagori { get; set; }


        

    }
}