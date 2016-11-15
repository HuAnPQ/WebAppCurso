using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppCurso.Models;

namespace WebAppCurso.Controllers
{
    [Authorize(Roles = "Administrador, Solicitante")]
    public class HerederosController : Controller
    {
        private Entities_FacciRentas db = new Entities_FacciRentas();

        // GET: Herederos
        public ActionResult Index()
        {
            return View(db.Herederoes.ToList());
        }

        // GET: Herederos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heredero heredero = db.Herederoes.Find(id);
            if (heredero == null)
            {
                return HttpNotFound();
            }
            return View(heredero);
        }

        // GET: Herederos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Herederos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Usuario,Cedula,Nombre,Direccion,TipoHeredero")] Heredero heredero)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    heredero.Usuario = User.Identity.Name; //User.Identity.GetUserName()
                    db.Herederoes.Add(heredero);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Problemas al guardar el nuevo Heredero." + Environment.NewLine + ex.Message);
                    return View(heredero);
                }

            }

            return View(heredero);
        }

        // GET: Herederos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heredero heredero = db.Herederoes.Find(id);
            if (heredero == null)
            {
                return HttpNotFound();
            }
            return View(heredero);
        }

        // POST: Herederos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Usuario,Cedula,Nombre,Direccion,TipoHeredero")] Heredero heredero)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(heredero).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(heredero);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Problemas al guardar el nuevo Heredero." + Environment.NewLine + ex.Message);
                return View(heredero);
            }
        }

        // GET: Herederos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heredero heredero = db.Herederoes.Find(id);
            if (heredero == null)
            {
                return HttpNotFound();
            }
            return View(heredero);
        }

        // POST: Herederos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Heredero heredero = db.Herederoes.Find(id);
                db.Herederoes.Remove(heredero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Problemas al guardar el nuevo Heredero." + Environment.NewLine + ex.Message);
                return RedirectToAction("Index");
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
