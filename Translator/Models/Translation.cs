using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Translator.Models
{
    public class Translation
    {
        [Key,Column(Order = 1)]
        [ForeignKey("RussianWord")]
        public int RussianWordId { set; get; }
        public virtual RussianWord RussianWord { set; get; }

        [Key, Column(Order = 2)]
        [ForeignKey("EnglishWord")]
        public int EnglishWordId { set; get; }
        public virtual EnglishWord EnglishWord { set; get; }

        [Column]
        public string Picture { set; get; }
    }
}