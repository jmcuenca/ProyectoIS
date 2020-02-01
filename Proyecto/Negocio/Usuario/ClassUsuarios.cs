using System;
using System.Collections.Generic;
using System.Linq;
using Modelo;

namespace Negocio
{
    public class ClassUsuarios
    {
       
        AsociacionEntities entidad = new AsociacionEntities();
        public string crudUsuario(Usuarios usuarios, string tipo) {
            var sltUsuario = entidad.Usuarios;
            var mensaje = "";
            // I = insert  U=update   D=delete
            try
            {
                if (tipo == "I")
                {
                    if (sltUsuario.Where(ced => ced.Cedula.Equals(usuarios.Cedula)).Count() == 0)
                    {
                        entidad.Usuarios.Add(usuarios);
                        entidad.SaveChanges();
                        mensaje = usuarios.IdUsuario.ToString();
                    }
                    else
                    {
                        mensaje = "El usuario ya esta registrado";
                    }
                }
                else if (tipo == "U")
                {
                    if (sltUsuario.Where(ced => ced.Cedula.Equals(usuarios.Cedula)).Count() > 0)
                    {
                        entidad.Usuarios.Add(usuarios);
                        entidad.SaveChanges();
                        mensaje = "Usuario actualizado con exito";
                    }
                    else
                    {
                        mensaje = "El usuario ya esta registrado";
                    }
                }
                else if (tipo == "D") 
                {
                    if (sltUsuario.Where(ced => ced.Cedula.Equals(usuarios.Cedula)).Count() > 0)
                    {
                        entidad.Usuarios.Remove(entidad.Usuarios.Where(x => x.IdUsuario == usuarios.IdUsuario).SingleOrDefault());
                        entidad.SaveChanges();
                        mensaje = "Usuario eliminado con exito";
                    }
                    else
                    {
                        mensaje = "El usuario aun no esta registrado";
                    }

                }  
            }
            catch (Exception)
            {

                mensaje = "Ocurrio un error, intentalo de nuevo";
            }
            

            return mensaje;
        }
        public List<Usuarios> consultarUsuarioId(string cedula) 
        {
            return entidad.Usuarios.Where(cod => cod.Cedula.Equals(cedula)).ToList();
        }
        public List<Usuarios> consultarUsuarios()
        {
            return entidad.Usuarios.ToList();
        }

    }
}
