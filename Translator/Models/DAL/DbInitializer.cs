using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Translator.Models.DAL
{
    public class DbInitializer: DropCreateDatabaseAlways<TranslatorContext>
    {
        protected override void Seed(TranslatorContext db)
        {
            EnglishWord ew1 = new EnglishWord { Id = 1, Word = "elephant", Transcription = "[ˈɛlɪf(ə)nt]" };
            db.EnglishWords.Add(ew1);

            RussianWord rw1 = new RussianWord { Id = 1, Word = "слон", Transcription = "[сло́н]" };
            db.RussianWords.Add(rw1);

            Translation tr1 = new Translation { EnglishWordId = 1, RussianWordId = 1, Picture = "~/Pictures/elephant.jpg" };
            db.Translations.Add(tr1);

            base.Seed(db);
        }
    }
}