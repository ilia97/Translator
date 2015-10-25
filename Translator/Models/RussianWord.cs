using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translator.Models
{
    public class RussianWord : LanguageWord
    {
        public RussianWord()
        {
            EnglishTranslations = new List<Translation>();
        }

        public virtual List<Translation> EnglishTranslations { set; get; }
    }
}