using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Web_Api_FAQBokhandel.Models;
using Web_Api_FAQBokhandel.Models.ViewModels;


namespace Web_Api_FAQBokhandel.Dal
{
    public class FaqDB : IFaqDb
    {
        FaqBokhandelContext db = new FaqBokhandelContext();

        
        public List<KundeSporsmolViewModel> hentAlleKundeSporsmoler()
        {
            List<KundeSporsmolViewModel> alleSporsmoler = db.KundeSporsmoler.Select(k => new KundeSporsmolViewModel()
            {
                Id = k.Id,
                Navn = k.kunde.Navn,
                Email = k.kunde.Email,
                KatagoriId = k.KatagoriId,
                KatagoriType = k.katagori.Type,
                Sporsmoltext = k.Sporsmoltext,
                Dato = k.Dato.ToString(),
               
                
            }).ToList();
            
            foreach(var i in alleSporsmoler )
            {
                i.Dato = i.Dato.Substring(0, 11);
            }
            


            return alleSporsmoler;
        }

        public List<KatagoriViewModel> hentAllekatagorier()
        {
            List<KatagoriViewModel> alleKatagorier = db.Katagorier.Select(k => new KatagoriViewModel()
            {
                Id = k.Id,
                Type = k.Type,
                Bilde = k.Bilde
              
            }
                ).ToList();
            return alleKatagorier;
        }

        public List<FaqViewModel> hentAlleFaqer()
        {
            List<FaqViewModel> alleFaqer = db.Faqer.Select(k => new FaqViewModel()
            {

                Id = k.Id,
                SporsmolText = k.SporsmolText,
                SvarText = k.SvarText,
                KatagoriId = k.katagori.Id

            }
                ).ToList();
            return alleFaqer;
        }

    
        public bool lagreEnsporsmol(KundeSporsmolViewModel innSporsmol)
        {
            DateTime dt = DateTime.Now;
            var innEmail = innSporsmol.Email;
            var innNavn = innSporsmol.Navn;
            var nySporsmol = new KundeSporsmol()
            { 
            
                Dato = dt,
                Id = innSporsmol.Id,
                KatagoriId = innSporsmol.KatagoriId,                
                Sporsmoltext = innSporsmol.Sporsmoltext, 
            };
            int kid = finnKunde(innNavn, innEmail);

            //Kunden finnes ikke i databasen
            if(kid == -1)
            {
                //opprett en ny kunde
                Kunde nykunde = new Kunde
                {
                    Email = innEmail,
                    Navn = innNavn
                };
                lagreEnKunde(nykunde);

                //finn kunde iden på nytt etter lagring
                kid = finnKunde(innNavn, innEmail);
            }
            //Knytt kunden til spørsmålet
            nySporsmol.KundeId = kid;
            db.KundeSporsmoler.Add(nySporsmol);
            db.SaveChanges();

            return true;
        }

        public int finnKunde(string navn, string email)
        {
            var funnetKunde = db.Kunder
                .SingleOrDefault(k => k.Email == email && k.Navn == navn);
            if (funnetKunde != null)
            {
                return funnetKunde.Id;
            }
            else
            {
                return -1;
            }
            
        }
        public bool lagreEnKunde(Kunde innKunde)
        {
            try
            {
                // lagre kunden
                db.Kunder.Add(innKunde);
                db.SaveChanges();
            }
            catch (Exception feil)
            {
                return false;
            }
            return true;
        }
    }
}