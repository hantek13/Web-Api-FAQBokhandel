using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Api_FAQBokhandel.Models;
using Web_Api_FAQBokhandel.Models.ViewModels;

namespace Web_Api_FAQBokhandel.Dal
{
    interface IFaqDb
    {
        List<KundeSporsmolViewModel> hentAlleKundeSporsmoler();
        List<KatagoriViewModel> hentAllekatagorier();
        List<FaqViewModel> hentAlleFaqer();
        bool lagreEnsporsmol(KundeSporsmolViewModel innSporsmol);
        int finnKunde(string navn, string email);
        bool lagreEnKunde(Kunde innKunde);
        
        
        
        







    }
}