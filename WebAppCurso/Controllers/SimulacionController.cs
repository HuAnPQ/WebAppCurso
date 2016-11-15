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
    [Authorize(Roles ="Administrador, Solicitante")]
    public class SimulacionController : Controller
    {
        private Entities_FacciRentas db = new Entities_FacciRentas();

        // GET: Simulacion
        public ActionResult Index()
        {
            return View(db.Simulacions
                .Where(s => s.Usuario.Equals(User.Identity.Name))
                .ToList());
        }

        // GET: Simulacion/Details/5
        /*
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Simulacion simulacion = db.Simulacions.Find(id);
            if (simulacion == null)
            {
                return HttpNotFound();
            }
            return View(simulacion);
        }
        */

        // GET: Simulacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Simulacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Usuario,CedulaSolicitante,NombreSolicitante,PatrimonioFamiliar,Herederos,Impuesto,PatrimonioHeredar,Fecha")] Simulacion simulacion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    simulacion.Usuario = User.Identity.Name; //User.Identity.GetUserName()
                    db.Simulacions.Add(simulacion);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(simulacion);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Problemas al guardar la nueva Simulacion." + Environment.NewLine + ex.Message);
                return View(simulacion);
            }
        }

        // GET: Simulacion/Edit/5
        /*
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Simulacion simulacion = db.Simulacions.Find(id);
            if (simulacion == null)
            {
                return HttpNotFound();
            }
            return View(simulacion);
        }
        

        // POST: Simulacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Usuario,CedulaSolicitante,NombreSolicitante,PatrimonioFamiliar,Herederos,Impuesto,PatrimonioHeredar")] Simulacion simulacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(simulacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(simulacion);
        }

        // GET: Simulacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Simulacion simulacion = db.Simulacions.Find(id);
            if (simulacion == null)
            {
                return HttpNotFound();
            }
            return View(simulacion);
        }

        // POST: Simulacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Simulacion simulacion = db.Simulacions.Find(id);
            db.Simulacions.Remove(simulacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        */
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
