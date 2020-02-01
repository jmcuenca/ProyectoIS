using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Negocio
{
    public class ClassRoles
    {
        AsociacionEntities entidad = new AsociacionEntities();
        public List<Roles_Usuarios> listarRolesUsuario() 
        {
            return entidad.Roles_Usuarios.ToList();
        }
        public string crearRolUsuario(Roles_Usuarios roles_Usuarios) {
            var mensaje = "";
            var datos = entidad.Roles_Usuarios.Where(x => x.IdUsuario == roles_Usuarios.IdUsuario);
            if (datos.Count()< 2)
            {
                if(datos.Where(x => x.IdUsuario == roles_Usuarios.IdUsuario && x.IdRol == roles_Usuarios.IdRol).Count()<1)
                entidad.Roles_Usuarios.Add(roles_Usuarios);
                entidad.SaveChanges();
                mensaje = "insertado con exito";
            }
            else 
            {
                mensaje = "ya existe el rol para el usuario";
            }

            return mensaje;

        }
        public string deleteRolUsuario(Roles_Usuarios roles_Usuarios) {
            Roles_Usuarios rol = entidad.Roles_Usuarios.Where(x => x.IdRol_Usuario == roles_Usuarios.IdRol_Usuario).SingleOrDefault();
            entidad.Roles_Usuarios.Remove(rol);
            entidad.SaveChanges();
            return "eliminado";
        }
        public List<Roles> listarRoles() {
            return entidad.Roles.ToList();
        }
        
    }
}
