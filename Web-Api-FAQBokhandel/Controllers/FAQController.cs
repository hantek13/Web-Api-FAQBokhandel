using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;
using Web_Api_FAQBokhandel.Dal;
using Web_Api_FAQBokhandel.Models.ViewModels;

namespace Web_Api_FAQBokhandel.Controllers
{
    public class FAQController : ApiController
    {
        FaqDB _faqDB = new FaqDB();

        //Get api/FAQ
        [HttpGet]
        [ActionName("KundeSporsmol")]
        public HttpResponseMessage GetKundeSporsmolViewModels()
        {
            List<KundeSporsmolViewModel> alleKundeSporsmol = _faqDB.hentAlleKundeSporsmoler();
           

            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(alleKundeSporsmol);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        [HttpGet]
        [ActionName("Katagorier")]
        public HttpResponseMessage GetKatagoriViewModels()
        {
            List<KatagoriViewModel> alleKatagorier = _faqDB.hentAllekatagorier();

            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(alleKatagorier);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        [HttpGet]
        [ActionName("Faqer")]
        public HttpResponseMessage GetFaqViewModel()
        {
            List<FaqViewModel> alleFaqer = _faqDB.hentAlleFaqer();

            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(alleFaqer);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }



        [HttpPost]
        [ActionName("KundeSporsmol")]
        public HttpResponseMessage Post([FromBody] KundeSporsmolViewModel innsporsmol)
        {
            if (ModelState.IsValid)
            {
                bool ok = _faqDB.lagreEnsporsmol(innsporsmol);
                if (ok)
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK
                    };

                }
            }
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent("Kunne ikke sette inn kunden i DB")
            };
        }
    }

}
