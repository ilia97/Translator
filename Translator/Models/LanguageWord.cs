using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Translator.Models
{
    public class LanguageWord
    {
        [Key]
        [Column]
        public int Id{ set; get; } 

        [Column]
        public string Word { set; get; }

        [Column]
        public string Transcription { set; get; }
    }
}