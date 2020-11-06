using GreenNews.DataBase;
using GreenNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;

namespace GreenNews.Controllers
{
    public class HomeController : Controller
    {
        public ArtigoContexto db = new ArtigoContexto();

        public ActionResult Index()
        {
            ViewBag.nome = NomeTags();
            ViewBag.qtdArtigo = ContarTagsArtigos();

            return View();
        }

        // P
        public List<string> NomeTags()
        {
            var catTag = new List<string>();

            foreach (Tag t in db.Tags)
            {
                catTag.Add(t.Nome);
            }

            return catTag;
        }

        public int ArtigoPorTag(int Id)
        {
            var artTag = db.Artigos.Where($"TagId == {Id}");

            int  qtdArtTag = artTag.Count();

            return qtdArtTag;
        }

        public int CountTags()
        {
            var qtdTags = db.Tags.Count();

            return qtdTags;
        }

        public List<int> ContarTagsArtigos()
        {
            var nTags = new List<int>();

            for (int i = 0; i < CountTags(); i++)
            {
                nTags.Add(ArtigoPorTag(i+1));
            }

            return nTags;
        }



    }
}