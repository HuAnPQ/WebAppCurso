//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppCurso.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Habitacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Habitacion()
        {
            this.DetalleReservas = new HashSet<DetalleReserva>();
        }
    
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int Tipo_Id { get; set; }
        public double Precio { get; set; }
        public string Foto { get; set; }
        public int Estado_Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleReserva> DetalleReservas { get; set; }
        public virtual GruposHabitacion GruposHabitacion { get; set; }
        public virtual GruposHabitacion GruposHabitacion1 { get; set; }
    }
}
