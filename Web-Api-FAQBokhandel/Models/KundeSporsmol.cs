using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Web_Api_FAQBokhandel.Models
{
    public class KundeSporsmol
    {
        [Key]
        public int Id { get; set; }        
        public string Sporsmoltext { get; set; }
        public int KatagoriId { get; set; }
        public int KundeId { get; set; }
        public DateTime? Dato { get; set; }
        public virtual Katagori katagori { get; set; }
        public virtual Kunde kunde { get; set; }
    }
}