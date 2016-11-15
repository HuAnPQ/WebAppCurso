using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormFacciRentas.Logica
{
    public class Simulacion
    {

        public int Id { get; set; }
        public string Usuario { get; set; }
        public string CedulaSolicitante { get; set; }
        public string NombreSolicitante { get; set; }
        public double PatrimonioFamiliar { get; set; }
        public int Herederos { get; set; }
        public double Impuesto { get; set; }
        public double PatrimonioHeredar { get; set; }

    }
}
