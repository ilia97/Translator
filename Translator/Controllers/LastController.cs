using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Translator.Models;
using Translator.Models.DAL;

namespace Translator.Controllers
{
    public class LastController : Controller
    {
        // GET: Last
        TranslatorContext db = new TranslatorContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetWords(string text, string lang)
        {
            text = text.ToLower();
            List<Translation> l = new List<Translation>();
            if (lang == "Английский")
            {
                if (text == "")
                {
                    foreach (var x in db.Translations)
                        l.Add(x);
                }
                else
                {
                    foreach (var x in db.Translations.ToList())
                    {
                        int z = 0;
                        if (text.Length < x.EnglishWord.Word.Length)
                        {
                            for (int i = 0; i < text.Length; i++)
                            {
                                if (text[i] != x.EnglishWord.Word[i])
                                {
                                    z = -1;
                                    break;
                                }
                            }
                            if (z != -1)
                                l.Add(x);
                        }
                    }
                }
                l = l.OrderBy(x => x.EnglishWord.Word).ToList();
                return PartialView(l);
            }
            else
            {
                if (text == "")
                {
                    foreach (var x in db.Translations)
                        l.Add(x);
                }
                else
                {
                    foreach (var x in db.Translations.ToList())
                    {
                        int z = 0;
                        if (text.Length < x.RussianWord.Word.Length)
                        {
                            for (int i = 0; i < text.Length; i++)
                            {
                                if (text[i] != x.RussianWord.Word[i])
                                {
                                    z = -1;
                                    break;
                                }
                            }
                            if (z != -1)
                                l.Add(x);
                        }
                    }
                }
                l = l.OrderBy(x => x.RussianWord.Word).ToList();
                return PartialView("GetWo", l);
            }

        }
    }
}
