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
        // GET: Producto
        public ActionResult Index()
        {
            ClassCategoria classCategoria = new ClassCategoria();
            ViewData["listarCategorias"] = classCategoria.listarCategorias();
            return View();
        }
        public ActionResult guardarProducto(HttpPostedFileBase file) 
        {
            ClassProducto classProducto = new ClassProducto();
            Productos productos = new Productos();
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
                    CultureInfo provider = new CultureInfo("en-US");
                    NumberStyles style= NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;

                    file.InputStream.CopyTo(ms);
                    productos.Imagen = ms.GetBuffer();
                    productos.NombreProducto = Request.Form["NombreProducto"].ToString();
                    productos.IdCategoria = Convert.ToInt32( Request.Form["IdCategoria"]);
                    productos.Precio = Decimal.Parse(Request.Form["Precio"].ToString(), style, provider);
                    productos.Stock = Convert.ToInt16(Request.Form["Stock"].ToString());
                    productos.Peso =  Double.Parse(Request.Form["Peso"],style,provider);
                    classProducto.crudProduct(productos, "I");
                }
            }
            /** 
            Transforma a base 64 lo cual permite decodificar la imagen
            var datos =Convert.ToBase64String(ms.GetBuffer());
            */
            
            
            return null;
        }
    }
}