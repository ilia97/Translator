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
    }
}