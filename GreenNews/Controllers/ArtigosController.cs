using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GreenNews.DataBase;
using GreenNews.Models;

namespace GreenNews.Controllers
{
    public class ArtigosController : Controller
    {
        private ArtigoContexto db = new ArtigoContexto();

        // GET: Artigos
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Listar(string searchPhrase, int current = 1, int rowCount = 5)
        {
            string chave = Request.Form.AllKeys.Where(k => k.StartsWith("sort")).First();
            string ordenacao = Request[chave];
            string campo = chave.Replace("sort[", String.Empty).Replace("]", String.Empty);

            var artigos = db.Artigos.Include(a => a.Tag);
            int total = artigos.Count();

            if (!string.IsNullOrWhiteSpace(searchPhrase) )
            {
                int ano = 0;
                int.TryParse(searchPhrase, out ano);

                artigos = artigos.Where("Titulo.Contains(@0) OR Autor.Contains(@0) OR DataCriacao == @1", searchPhrase, ano);
            }

            string campoOrdenacao = String.Format("{0} {1}", campo, ordenacao);

            var artigosPaginados = artigos.OrderBy(campoOrdenacao).Skip((current - 1) * rowCount).Take(rowCount);

            return Json(new { 
                rows = artigosPaginados.ToList(), 
                current = current, 
                rowCount = rowCount,
                total = total
            }, JsonRequestBehavior.AllowGet);
        }

        // GET: Artigos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artigo artigo = db.Artigos.Find(id);
            if (artigo == null)
            {
                return HttpNotFound();
            }
            return PartialView(artigo);
        }

        // GET: Artigos/Create
        public ActionResult Create()
        {
            ViewBag.TagId = new SelectList(db.Tags, "Id", "Nome");
            return PartialView();
        }

        // POST: Artigos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create([Bind(Include = "Id,Titulo,DataCriacao,Autor,Texto,TagId")] Artigo artigo)
        {
            if (ModelState.IsValid)
            {
                db.Artigos.Add(artigo);
                db.SaveChanges();
                //return RedirectToAction("Index");

                return Json(new { resultado = true, mensagem = "Artigo cadastrado com sucesso" });
            }else
            {
                IEnumerable<ModelError> erros = ModelState.Values.SelectMany(item => item.Errors);

                return Json(new { resultado = false, mensagem = erros });
            }

        }

        // GET: Artigos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artigo artigo = db.Artigos.Find(id);
            if (artigo == null)
            {
                return HttpNotFound();
            }
            ViewBag.TagId = new SelectList(db.Tags, "Id", "Nome", artigo.TagId);
            return PartialView(artigo);
        }

        // POST: Artigos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit([Bind(Include = "Id,Titulo,DataCriacao,Autor,Texto,TagId")] Artigo artigo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artigo).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { resultado = true, mensagem = "Artigo editado com sucesso" });

            }else
            {
                IEnumerable<ModelError> erros = ModelState.Values.SelectMany(item => item.Errors);

                return Json(new { resultado = false, mensagem = erros });
            }
        }

        // GET: Artigos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artigo artigo = db.Artigos.Find(id);
            if (artigo == null)
            {
                return HttpNotFound();
            }
            return PartialView(artigo);
        }

        // POST: Artigos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Artigo artigo = db.Artigos.Find(id);
                db.Artigos.Remove(artigo);
                db.SaveChanges();
                
                return Json(new { resultado = true, mensagem = "Artigo excluir com sucesso" });

            }
            catch(Exception ex)
            {
                return Json(new { resultado = false, mensagem = ex.Message });
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
