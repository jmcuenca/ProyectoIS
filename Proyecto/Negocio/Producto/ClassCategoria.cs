using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Negocio
{
    public class ClassCategoria
    {
        AsociacionEntities entities = new AsociacionEntities();

        public List<Categorias> listarCategorias() {
            return entities.Categorias.ToList();
        }
    }
}
