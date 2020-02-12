using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
namespace Negocio.Producto
{
    public class ClassCatalogo
    {
        AsociacionEntities contexto = new AsociacionEntities();

        public List<Productos> listarProductoCategoriaCategorias()
        {            
            return contexto.Productos.Include("Categorias").ToList();
        }
    }
}
