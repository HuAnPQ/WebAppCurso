using WebAppCurso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Habitaciones.Web.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ReporteController : Controller
    {
        
        private Entities_FacciRentas db = new Entities_FacciRentas();
        //
        // GET: /Reporte/
        public ActionResult Index()
        {
            return View();
        }

        /*
        public ActionResult Reporte_Ruc()
        {
            return View();
        }
        
        [HttpGet]
        [System.Web.Services.WebMethod]
        public string Reportes_Ruc(string Ruc_Cliente)
        {
            //Fecha_Prestamo = "01/09/2016";
            //Fecha_Entrega = "30/09/2016";
            var consulta = from simu in db.Simulacions.ToList()
                           where (simu.Cliente.Ruc_Cliente == Ruc_Cliente)
                           select new
                           {
                               Id_Reserva = simu.Id_Reserva,
                               Id_Cliente = simu.Cliente.Ruc_Cliente,
                               Fecha_Inicio = Convert.ToDateTime(simu.Fecha_Inicio).ToString("yyyy-MM-dd"),
                               Fecha_Final = Convert.ToDateTime(simu.Fecha_Final).ToString("yyyy-MM-dd"),
                               Subtotal = simu.Subtotal,
                               Descuento = simu.Descuento,
                               Iva = simu.Iva,
                               Total = simu.Total
                           };

            return Newtonsoft.Json.JsonConvert.SerializeObject(consulta);
        }

        [HttpPost]
        [System.Web.Services.WebMethod]
        public ActionResult Reporte_RucPdf(string Ruc_Cliente)
        {
            var reporte1 = from cliente in db.Reserva.ToList()
                           where (cliente.Cliente.Ruc_Cliente == Ruc_Cliente)
                           select cliente;
            return new Rotativa.ViewAsPdf("Reporte_RucPdf", reporte1.ToList());
        }
        */

        public ActionResult Reporte_Meses()
        {           
            return View();
        }

        [HttpGet]
        [System.Web.Services.WebMethod]
        public string Reportes_Meses(int Mes)
        {


            //Fecha_Prestamo = "01/09/2016";
            //Fecha_Entrega = "30/09/2016";
            var consulta = from simu in db.Simulacions.ToList()
                           where (simu.Fecha.Month == Mes)
                           orderby(simu.CedulaSolicitante),(simu.Fecha)
                           
                           select new
                           {
                               Usuario = simu.Usuario,
                               PatrimonioFamiliar = simu.PatrimonioFamiliar,
                               Impuesto = simu.Impuesto,
                               Herederos = simu.Herederos,
                               PatrimonioHeredar = simu.PatrimonioHeredar
                           };

            return Newtonsoft.Json.JsonConvert.SerializeObject(consulta);
        }

        [HttpPost]
        [System.Web.Services.WebMethod]
        public ActionResult Reportes_MesesPdf(int Mes)
        {
            var consulta = from simu in db.Simulacions.ToList()
                           where (simu.Fecha.Month == Mes)
                           orderby (simu.CedulaSolicitante), (simu.Fecha)
                           select simu;
            return new Rotativa.ViewAsPdf("Reportes_MesesPdf", consulta.ToList());
        }

    

    }
}