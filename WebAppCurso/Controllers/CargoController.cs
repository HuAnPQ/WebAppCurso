using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppCurso.Models;

namespace WebAppCurso.Controllers
{
    public class CargoController : Controller
    {
        private Entities_Escuela entidad;
        public CargoController()
        {
            entidad = new Entities_Escuela();
        }


        // GET: Cargo
        public ActionResult Index()
        {
            var listaCargos = entidad.Cargoes;
            return View(listaCargos.ToList());
        }

        // GET: Cargo/ListadoMaestraCargos
        public ActionResult ListadoMaestraCargos()
        {
            var listaCargos = entidad.Cargoes;
            return View(listaCargos.ToList());
        }

        // GET: Cargo/UsuarioPorCargo
        public ActionResult UsuariosPorCargo(string cargo_descrip)
        {
            var listaUsariosCargo = from usuario in entidad.Usuarios
                                    where usuario.Cargo.Descripcion == cargo_descrip
                                    select usuario;

            return View(listaUsariosCargo.ToList());
        }

        // GET: Cargo/UsuarioPorCargo
        public ActionResult UsuariosConDescripcionCargo(string cargo_descrip)
        {
            var listaUsariosCargoDescrip = from usuario in entidad.Usuarios
                                    join cargo in entidad.Cargoes
                                    on usuario.CargoId equals cargo.Id
                                    select new UsuarioCargo
                                    {
                                        IdUsuario = usuario.Id,
                                        NombreUsuario = usuario.Nombre,
                                        DescripcionCargo = cargo.Descripcion
                                    };

            return View(listaUsariosCargoDescrip.ToList());
        }

    }
}