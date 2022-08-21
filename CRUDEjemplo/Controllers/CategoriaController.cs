using Microsoft.AspNetCore.Mvc;
using CRUDEjemplo.Data;
using CRUDEjemplo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEjemplo.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoriaController(ApplicationDbContext context)
        {
            _context = context;

        }
        //http GET index

        public IActionResult Index()
        {
            IEnumerable<Categoria> Listacategorias = _context.Categorias;
            return View(Listacategorias);
        }

        public IActionResult Create()
        {

            return View();
        }

        //http POST create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoria.CreatedAt = DateTime.Now;
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
                TempData["mensaje"] = "La categoria se ha creado correctamente";
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
            var Categoria = _context.Categorias.Find(id);

            if (Categoria == null)
            {

                return NotFound();
            }


            return View(Categoria);
        }
        //http POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoria.UpdateAt = DateTime.Now;
                _context.Categorias.Update(categoria);
                _context.SaveChanges();
                TempData["mensaje"] = "La categoria se ha modificado  correctamente";
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
            var Categoria = _context.Categorias.Find(id);

            if (Categoria == null)
            {

                return NotFound();
            }


            return View(Categoria);
        }
        //http POST delete
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteCategoria(int? id)
        {
            var categoria = _context.Categorias.Find(id);
            var productos = _context.Productos.SingleOrDefault(x => x.IdCategoria == id);

            if (categoria == null)
            {
                return NotFound();
            }
            if (productos != null)
            {
                TempData["mensaje"] = "ERROR: La categoria tiene productos asociados";

                
            }
            else 
            {
                _context.Categorias.Remove(categoria);
                _context.SaveChanges();
                TempData["mensaje"] = "La categoria se ha eliminado  correctamente";
            }
            
            return RedirectToAction("Index");

        }
    }
}
