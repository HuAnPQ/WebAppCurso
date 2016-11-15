using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebAppCurso.Models
{
    public class Roles
    {
        private List<IdentityRole> roles;
        private List<Roles> ListaRoles;

        public Roles(List<IdentityRole> roles)
        {
            this.roles = roles;            
            CargarRoles();
        }

        public Roles()
        {
            InicializarProp();
        }

        private void CargarRoles()
        {
            ListaRoles = new List<Roles>();
            foreach (var rol in roles)
            {
                Roles rolUsu = new Roles();
                rolUsu.Nombre = rol.Name;
                foreach (var rolUser in rol.Users)
                {
                    using (ApplicationDbContext contexto = new ApplicationDbContext())
                    {
                        var usuario = contexto.Users
                            .Where(u => u.Id.Equals(rolUser.UserId))
                            .Select(u => u.UserName)
                            .FirstOrDefault();

                        if (usuario != null) rolUsu.Usuarios.Add(usuario);
                    }
                }
                ListaRoles.Add(rolUsu);
            }
        }

        private void InicializarProp()
        {
            Nombre = string.Empty;
            Usuarios = new List<string>();
        }

        public List<Roles> ListarRoles()
        {
            if (ListaRoles != null) return ListaRoles;
            return new List<Roles>(); 
        }

        public string Nombre { get; set; }
        public List<string> Usuarios { get; set; }

    }
}