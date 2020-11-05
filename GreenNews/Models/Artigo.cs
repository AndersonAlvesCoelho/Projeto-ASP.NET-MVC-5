using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenNews.Models
{
    public class Artigo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int DataCriacao { get; set; }
        public string Autor { get; set; }
        public string Texto { get; set; }

        public Tag Tag { get; set; }
        public int TagId { get; set; }

        internal Artigo Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}