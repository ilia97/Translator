using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Translator.Models.DAL
{
    public class TranslatorContext: DbContext
    {
        public DbSet<EnglishWord> EnglishWords { set; get; }
        public DbSet<RussianWord> RussianWords { set; get; }
        public DbSet<Translation> Translations { set; get; }
    }
}