using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEjemplo.Models
{
    public class ViewModels
    {
        public List<Categoria> Categorias  { get; set; }
        public Producto Producto { get; set; }
        public ViewModels()
        {
            this.Categorias = new List<Categoria>();
            this.Producto = new Producto();
        }
    }
    public class ViewModels2
    {
        public List<Categoria> Categorias { get; set; }
        public List<Producto> Productos { get; set; }
        public ViewModels2()
        {
            this.Categorias = new List<Categoria>();
            this.Productos = new List<Producto>();
        }
    }

}
