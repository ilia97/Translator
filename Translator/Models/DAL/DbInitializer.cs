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

            db.EnglishWords.Add(new EnglishWord { Id = 1, Word = "elephant", Transcription = "[ˈɛlɪf(ə)nt]" });
            db.EnglishWords.Add(new EnglishWord { Id = 2, Word = "apple", Transcription = "[ ˈæp.l̩ ]" });
            db.EnglishWords.Add(new EnglishWord { Id = 3, Word = "banana", Transcription = "[ bəˈnɑː.nə ]" });
            db.EnglishWords.Add(new EnglishWord { Id = 4, Word = "bamboo", Transcription = "[ bæmˈbuː ]" });
            db.EnglishWords.Add(new EnglishWord { Id = 5, Word = "bomb", Transcription = "[ bɒm ]" });
            db.EnglishWords.Add(new EnglishWord { Id = 6, Word = "cream", Transcription = "[ kriːm ]" });

            
            db.RussianWords.Add(new RussianWord { Id = 1, Word = "слон", Transcription = "[сло́н]" });
            db.RussianWords.Add(new RussianWord { Id = 2, Word = "яблоко", Transcription = "[я́блоко]" });
            db.RussianWords.Add(new RussianWord { Id = 3, Word = "банан", Transcription = "[бана́н]" });
            db.RussianWords.Add(new RussianWord { Id = 4, Word = "бамбук", Transcription = "[бʌмбу́к]" });
            db.RussianWords.Add(new RussianWord { Id = 5, Word = "бомба", Transcription = "[бо́мба]" });
            db.RussianWords.Add(new RussianWord { Id = 6, Word = "крем", Transcription = "[кр'е́м]" });

            db.Translations.Add(new Translation { EnglishWordId = 1, RussianWordId = 1, Picture = "~/Pictures/elephant.jpg" });
            db.Translations.Add(new Translation { EnglishWordId = 2, RussianWordId = 2, Picture = "~/Pictures/apple.jpg" });
            db.Translations.Add(new Translation { EnglishWordId = 3, RussianWordId = 3, Picture = "~/Pictures/banana.jpg" });
            db.Translations.Add(new Translation { EnglishWordId = 4, RussianWordId = 4, Picture = "~/Pictures/bamboo.jpg" });
            db.Translations.Add(new Translation { EnglishWordId = 5, RussianWordId = 5, Picture = "~/Pictures/bomb.jpg" });
            db.Translations.Add(new Translation { EnglishWordId = 6, RussianWordId = 6, Picture = "~/Pictures/cream.jpg" });

            base.Seed(db);
        }
    }
}