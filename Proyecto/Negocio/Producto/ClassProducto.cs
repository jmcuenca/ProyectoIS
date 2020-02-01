using System;
using System.Collections.Generic;
using System.Linq;
using Modelo;


namespace Negocio
{
    public class ClassProducto
    {
        AsociacionEntities entidad = new AsociacionEntities();
        public string crudProduct(Productos productos, string tipo)
        {
            var sltProducto = entidad.Productos;
            var mensaje = "";
            // I = insert  U=update   D=delete
            try
            {
                if (tipo == "I")
                {
                    if (sltProducto.Where(ced => ced.IdProducto.Equals(productos.IdProducto)).Count() == 0)
                    {
                        entidad.Productos.Add(productos);
                        entidad.SaveChanges();
                        mensaje = "Producto registrado con exito";
                    }
                    else
                    {
                        mensaje = "El producto ya esta registrado";
                    }
                }
                else if (tipo == "U")
                {
                    if (sltProducto.Where(ced => ced.IdProducto.Equals(productos.IdProducto)).Count() > 0)
                    {
                        entidad.Productos.Add(productos);
                        entidad.SaveChanges();
                        mensaje = "Producto actualizado con exito";
                    }
                    else
                    {
                        mensaje = "El producto ya esta registrado";
                    }
                }
                else if (tipo == "D")
                {
                    if (sltProducto.Where(ced => ced.IdProducto.Equals(productos.IdProducto)).Count() > 0)
                    {
                        entidad.Productos.Remove(productos);
                        entidad.SaveChanges();
                        mensaje = "Producto eliminado con exito";
                    }
                    else
                    {
                        mensaje = "El producto aun no esta registrado";
                    }

                }
            }
            catch (Exception)
            {

                mensaje = "Ocurrio un error, intentalo de nuevo";
            }


            return mensaje;
        }
        public List<Productos> listarProductos() {
            return entidad.Productos.ToList();
        }
        public Productos listarProductosId(int id)
        {
            return entidad.Productos.Where(cod=>cod.IdProducto==id).SingleOrDefault();
        }
    }
}
