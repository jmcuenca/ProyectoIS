using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Modelo;
using System.Globalization;

namespace WebApiCore.Controllers
{
    public class ProductoController : Controller
    {
        public ActionResult Index(Productos productos, string mensaje)
        {
            ClassCategoria classCategoria = new ClassCategoria();
            ViewData["listarCategorias"] = classCategoria.listarCategorias();
            ViewData["mensaje"] = mensaje;
            return View(productos);
        }
        public ActionResult guardarProducto(HttpPostedFileBase file) 
        {
            var msg = "";

            ClassProducto classProducto = new ClassProducto();
            Productos productos = new Productos();

            CultureInfo provider = new CultureInfo("en-US");
            NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;

            try
            {
                productos.NombreProducto = Request.Form["NombreProducto"].ToString();
                productos.IdCategoria = Convert.ToInt32(Request.Form["IdCategoria"]);
                productos.Precio = Decimal.Parse(Request.Form["Precio"].ToString(), style, provider);
                productos.Stock = Convert.ToInt16(Request.Form["Stock"].ToString());
                productos.Peso = Double.Parse(Request.Form["Peso"], style, provider);

                if (file != null)
                {
                    string path = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    file.SaveAs(path + Path.GetFileName(file.FileName));

                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        productos.Imagen = ms.GetBuffer();
                    }
                    Productos p = new Productos();
                    msg = classProducto.crudProduct(productos, "I");
                    return RedirectToAction("listarProducto", "Producto", new { producto = p, mensaje = msg });
                }
                else
                {
                    Productos productos1 = productos;
                    msg = "Por favor elija una foto para continuar";
                    return RedirectToAction("Index", "Producto", new { productos = productos1, mensaje = msg });
                }
            }
            catch (Exception)
            {
                Productos p2 = new Productos();
                msg = "Ocurrio un error vuelve a intentarlo";
                return RedirectToAction("Index", "Producto", new { producto = p2, mensaje = msg });
            }
            
            /** 
            Transforma a base 64 lo cual permite decodificar la imagen
            var datos =Convert.ToBase64String(ms.GetBuffer());
            */
        }
        public ActionResult listarProducto() {
            ClassProducto producto = new ClassProducto();
            ViewData["listarProducto"] = producto.listarProductos();
            return View();
        }
        public JsonResult listarId(int id) 
        {
            ClassProducto classProducto = new ClassProducto();
            Productos pro = classProducto.listarProductosId(id);
            return Json(pro,JsonRequestBehavior.AllowGet);
        }
    }
}