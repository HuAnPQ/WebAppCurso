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
    [Authorize(Roles ="Administrador, Recepcionista")]
    public class GruposHabitacionesController : Controller
    {
        private Entities_Hotel db = new Entities_Hotel();

        // GET: GruposHabitaciones
        public ActionResult Index()
        {
            return View(db.GruposHabitacions.ToList());
        }

        // GET: GruposHabitaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GruposHabitacion gruposHabitacion = db.GruposHabitacions.Find(id);
            if (gruposHabitacion == null)
            {
                return HttpNotFound();
            }
            return View(gruposHabitacion);
        }

        // GET: GruposHabitaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GruposHabitaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Tipo")] GruposHabitacion gruposHabitacion)
        {
            if (ModelState.IsValid)
            {
                db.GruposHabitacions.Add(gruposHabitacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gruposHabitacion);
        }

        // GET: GruposHabitaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GruposHabitacion gruposHabitacion = db.GruposHabitacions.Find(id);
            if (gruposHabitacion == null)
            {
                return HttpNotFound();
            }
            return View(gruposHabitacion);
        }

        // POST: GruposHabitaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Tipo")] GruposHabitacion gruposHabitacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gruposHabitacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gruposHabitacion);
        }

        // GET: GruposHabitaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GruposHabitacion gruposHabitacion = db.GruposHabitacions.Find(id);
            if (gruposHabitacion == null)
            {
                return HttpNotFound();
            }
            return View(gruposHabitacion);
        }

        // POST: GruposHabitaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GruposHabitacion gruposHabitacion = db.GruposHabitacions.Find(id);
            db.GruposHabitacions.Remove(gruposHabitacion);
            db.SaveChanges();
            return RedirectToAction("Index");
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
