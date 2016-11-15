using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppCurso.Models;

namespace WebAppCurso.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext contexto;

        public RoleController()
        {
            contexto = new ApplicationDbContext();
        }

        // GET: Role
        public ActionResult Index()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    if (EsUsuarioAdmin())
            //    {
            //        var roles = contexto.Roles.ToList();
            //        Roles rolesUsuarios = new Roles(roles);
            //        return View(rolesUsuarios.ListarRoles());
            //    }
            //}
            //return RedirectToAction("Index", "Home");
            var roles = contexto.Roles.ToList();
            Roles rolesUsuarios = new Roles(roles);
            return View(rolesUsuarios.ListarRoles());
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            var nuevoRol = new IdentityRole();
            return View(nuevoRol);
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(IdentityRole nuevoRol)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid || string.IsNullOrEmpty(nuevoRol.Name))
                {
                    ModelState.AddModelError("", "Ingrese el nombre del nuevo rol.");
                    return View(nuevoRol);
                }
                contexto.Roles.Add(nuevoRol);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Problemas al guardar el nuevo rol.");
                return View(nuevoRol);
            }
        }

        private bool EsUsuarioAdmin()
        {
            var user = User.Identity;
            ApplicationDbContext contexto = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(contexto));
            var roles = UserManager.GetRoles(user.GetUserId());
            if (roles[0].ToString() == "Admin")
            {
                return true;
            }
            return false;
        }

    }
}
