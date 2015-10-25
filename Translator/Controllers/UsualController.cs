using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Translator.Models;
using Translator.Models.DAL;

namespace Translator.Controllers
{
 
    public class UsualController : Controller
    {
        TranslatorContext db = new TranslatorContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Translations.ToList());
        }
        [HttpPost]
        public ActionResult GetWord(string Lab, string text) {
            text = text.ToLower();
            LanguageWord l = new LanguageWord();
            if (text == null)
            {
                l.Id = 123;
                l.Word = "";
            }
            else if (Lab == "Английский")
            {
                if (db.EnglishWords.Where(x => x.Word == text).Count() != 0)
                {
                    l.Word = db.EnglishWords.Where(x => x.Word == text).First().RussianTranslations.First().RussianWord.Word;
                }
                else {
                    l.Word = text;
                }
            }
            else {
                if (db.RussianWords.Where(x => x.Word == text).Count() != 0)
                {
                    l.Word = db.RussianWords.Where(x => x.Word == text).First().EnglishTranslations.First().EnglishWord.Word;
                }
                else
                {
                    l.Word = text;
                }
            }
            return PartialView(l);
        }
    }
}