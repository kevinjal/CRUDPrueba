using Microsoft.AspNetCore.Mvc;
using CRUDEjemplo.Data;
using CRUDEjemplo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEjemplo.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductosController(ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            //IEnumerable<Producto> Listaproductos = _context.Productos;
            //return View(Listaproductos);
            ViewModels2 model = new ViewModels2();
            model.Categorias = _context.Categorias.ToList();
            model.Productos = _context.Productos.ToList();
            return View(model);


        }
        public IActionResult Create()
        {
            ViewModels model = new ViewModels();
            model.Categorias = _context.Categorias.ToList();
         
            
            return View(model);
        }
        //http POST create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                producto.CreatedAt = DateTime.Now;
                _context.Productos.Add(producto);
                _context.SaveChanges();
                TempData["mensaje"] = "El producto se ha creado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }
        //http GET edit

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            
            ViewModels model = new ViewModels();
            model.Categorias = _context.Categorias.ToList();
            model.Producto = _context.Productos.Find(id);

            if (model.Producto == null)
            {

                return NotFound();
            }


            return View(model);
        }
        //http POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                producto.UpdateAt = DateTime.Now;
                _context.Productos.Update(producto);
                _context.SaveChanges();
                TempData["mensaje"] = "El producto se ha modificado  correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }
        //http GET delete

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var producto = _context.Productos.Find(id);

            if (producto == null)
            {

                return NotFound();
            }


            return View(producto);
        }
        //http POST delete
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteProducto(int? id)
        {
            var producto = _context.Productos.Find(id);


            if (producto == null)
            {
                return NotFound();
            }
            _context.Productos.Remove(producto);
            _context.SaveChanges();
            TempData["mensaje"] = "El producto se ha eliminado  correctamente";
            return RedirectToAction("Index");

        }
    }

}

