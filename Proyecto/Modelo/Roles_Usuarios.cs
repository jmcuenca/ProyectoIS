//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Roles_Usuarios
    {
        public int IdRol_Usuario { get; set; }
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
    
        public virtual Roles Roles { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
