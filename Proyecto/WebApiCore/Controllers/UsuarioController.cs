using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Modelo;

namespace WebApiCore.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index(Usuarios usuarios,string mensaje)
        {

            ClassRoles roles = new ClassRoles();
            ViewData["listarRoles"] = roles.listarRoles();
            if (mensaje != null )
            {
                ViewData["mensaje"] = mensaje;
            }
            else 
            {
                ViewData["mensaje"] =null;
            }
            

            return View(usuarios);
        }
        public ActionResult guardarUsuario() {
            ClassUsuarios classUsuarios = new ClassUsuarios();
            ClassRoles classRoles = new ClassRoles();
            

            Usuarios usuarios = new Usuarios();
            usuarios.NombreUsuario= Request.Form["NombreUsuario"].ToString();
            usuarios.ApellidoUsuario = Request.Form["ApellidoUsuario"].ToString();
            usuarios.Cedula = Request.Form["Cedula"].ToString();
            usuarios.Telefono = Request.Form["Telefono"].ToString();
            usuarios.Empresa = Request.Form["Empresa"].ToString();
            usuarios.Direccion = Request.Form["Direccion"].ToString();
            usuarios.Ciudad = Request.Form["Ciudad"].ToString();
            usuarios.Provincia = Request.Form["Provincia"].ToString();

            int idRol = Convert.ToInt32(Request.Form["Roles_Usuarios"]);

            if (classUsuarios.consultarUsuarioId(usuarios.Cedula).Count() > 0)
            {
                Roles_Usuarios roles_Usuarios = new Roles_Usuarios();
                roles_Usuarios.IdUsuario = classUsuarios.consultarUsuarioId(usuarios.Cedula).SingleOrDefault().IdUsuario;
                roles_Usuarios.IdRol = idRol;
                
                return RedirectToAction("Index", "Usuario", new { usuarios = classUsuarios.consultarUsuarioId(usuarios.Cedula).SingleOrDefault(), mensaje= classRoles.crearRolUsuario(roles_Usuarios) });
                
            }
            else 
            {
                var idUsuario = classUsuarios.crudUsuario(usuarios, "I");

                if (idUsuario != null || idUsuario != "")
                {
                    Roles_Usuarios roles_Usuarios = new Roles_Usuarios();
                    roles_Usuarios.IdUsuario = Convert.ToInt32(idUsuario);
                    roles_Usuarios.IdRol = idRol;
                    classRoles.crearRolUsuario(roles_Usuarios);
                }
                return RedirectToAction("Index", "Usuario");
            }
            

            
        }
        public ActionResult eliminarUsuario(int txtIdUSuario, int txtIdRol) 
        {

            //elimina roles x usuario
            Roles_Usuarios roles_Usuarios = new Roles_Usuarios();
            roles_Usuarios.IdRol_Usuario = txtIdRol;
            ClassRoles classRoles = new ClassRoles();
            classRoles.deleteRolUsuario(roles_Usuarios);

            //elimina usuario
            Usuarios usuarios = new Usuarios();
            usuarios.IdUsuario = txtIdUSuario;
            ClassUsuarios classUsuarios = new ClassUsuarios();
            classUsuarios.crudUsuario(usuarios, "D");

            return RedirectToAction("ListaUsuario", "Usuario");
        }
        public ActionResult ListaUsuario() {
            ClassUsuarios classUsuarios = new ClassUsuarios();
            ViewData["listarUsuarios"] = classUsuarios.consultarUsuarios();

            return View();
        }
        public ActionResult ListarUsuarioId(string cedula) {
            ClassUsuarios classUsuarios = new ClassUsuarios();
            Usuarios usuarios = new Usuarios();
            var datos = classUsuarios.consultarUsuarioId(cedula);
            if (datos.Count() > 0)
            {
                usuarios = datos.SingleOrDefault();
            }
            else 
            {
                usuarios.Cedula = cedula;
            }
            return RedirectToAction("Index", "Usuario", usuarios);
        }
        
    }
}