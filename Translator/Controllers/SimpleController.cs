using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Translator.Models;
using Translator.Models.DAL;

namespace Translator.Controllers
{
    public class SimpleController: Controller
    {
        TranslatorContext context = new TranslatorContext();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.EnglishWords = context.EnglishWords.ToList();
            ViewBag.RussianWords = context.RussianWords.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult GetTranslations(string word)
        {
            word = word.ToLower();
            List<Translation> englishTranslations = new List<Translation>();
            List<Translation> russianTranslations = new List<Translation>();

            if(context.EnglishWords.Count(ew => ew.Word.ToLower() == word) > 0)
            {
                russianTranslations = context.EnglishWords.First(ew => ew.Word.ToLower() == word).RussianTranslations;
            }
            else if (context.RussianWords.Count(rw => rw.Word.ToLower() == word) > 0)
            {
                englishTranslations = context.RussianWords.First(ew => ew.Word.ToLower() == word).EnglishTranslations;
            }

            ViewBag.EnglishTranslations = englishTranslations;
            ViewBag.RussianTranslations = russianTranslations;

            return PartialView("TranslationsListPartial");
        }
    }
}