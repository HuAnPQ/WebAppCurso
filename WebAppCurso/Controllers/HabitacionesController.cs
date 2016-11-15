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
    public class HabitacionesController : Controller
    {
        private Entities_Hotel db = new Entities_Hotel();

        // GET: Habitaciones
        public ActionResult Index()
        {
            var habitacions = db.Habitacions.Include(h => h.GruposHabitacion).Include(h => h.GruposHabitacion1);
            return View(habitacions.ToList());
        }

        // GET: Habitaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habitacion habitacion = db.Habitacions.Find(id);
            if (habitacion == null)
            {
                return HttpNotFound();
            }
            return View(habitacion);
        }

        // GET: Habitaciones/Create
        public ActionResult Create()
        {
            ViewBag.Estado_Id = new SelectList(db.GruposHabitacions, "Id", "Descripcion");
            ViewBag.Tipo_Id = new SelectList(db.GruposHabitacions, "Id", "Descripcion");
            return View();
        }

        // POST: Habitaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Tipo_Id,Precio,Foto,Estado_Id")] Habitacion habitacion, HttpPostedFileBase Foto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Foto.ContentLength > 0)
                    {
                        string rutaFoto_img = Server.MapPath("~/tempFotoHab/") + "Hab_" + habitacion.Codigo + "-" + Foto.FileName;
                        string rutaFoto_db = "/tempFotoHab/Hab_" + habitacion.Codigo + "-" + Foto.FileName;
                        //"C:\\TempFiles\\Hab_" + habitacion.Codigo+ "-" +Foto.FileName;
                        Foto.SaveAs(rutaFoto_img);
                        habitacion.Foto = rutaFoto_db;
                    }
                    db.Habitacions.Add(habitacion);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Errores al guadar los cambios: " + ex.Message);
                }
            }

            ViewBag.Estado_Id = new SelectList(db.GruposHabitacions, "Id", "Descripcion", habitacion.Estado_Id);
            ViewBag.Tipo_Id = new SelectList(db.GruposHabitacions, "Id", "Descripcion", habitacion.Tipo_Id);
            return View(habitacion);
        }


        // GET: Habitaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habitacion habitacion = db.Habitacions.Find(id);
            if (habitacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estado_Id = new SelectList(db.GruposHabitacions, "Id", "Descripcion", habitacion.Estado_Id);
            ViewBag.Tipo_Id = new SelectList(db.GruposHabitacions, "Id", "Descripcion", habitacion.Tipo_Id);
            return View(habitacion);
        }

        // POST: Habitaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Tipo_Id,Precio,Foto,Estado_Id")] Habitacion habitacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(habitacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estado_Id = new SelectList(db.GruposHabitacions, "Id", "Descripcion", habitacion.Estado_Id);
            ViewBag.Tipo_Id = new SelectList(db.GruposHabitacions, "Id", "Descripcion", habitacion.Tipo_Id);
            return View(habitacion);
        }

        // GET: Habitaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habitacion habitacion = db.Habitacions.Find(id);
            if (habitacion == null)
            {
                return HttpNotFound();
            }
            return View(habitacion);
        }

        // POST: Habitaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Habitacion habitacion = db.Habitacions.Find(id);
            db.Habitacions.Remove(habitacion);
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
