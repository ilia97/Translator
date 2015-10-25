using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translator.Models
{
    public class EnglishWord: LanguageWord
    {
        public EnglishWord()
        {
            RussianTranslations = new List<Translation>();
        }

        public virtual List<Translation> RussianTranslations { set; get; }
    }
}