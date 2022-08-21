using CRUDEjemplo.Data;
using CRUDEjemplo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEjemplo.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        //http GET index

        public IActionResult Index()
        {
            IEnumerable<Libro> Listalibros = _context.Libros;
            return View(Listalibros);
        }
        //http GET create
        public IActionResult Create()
        {
            
            return View();
        }
        //http POST create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Libro libro)
        {
            if (ModelState.IsValid) 
            {
                _context.Libros.Add(libro);
                _context.SaveChanges();
                TempData["mensaje"] = "El libro se ha creado correctamente";
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
            var Libro = _context.Libros.Find(id);

            if (Libro == null)
            {
                
                return NotFound();
            }
            

            return View(Libro);
        }

        //http POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libros.Update(libro);
                _context.SaveChanges();
                TempData["mensaje"] = "El libro se ha modificado  correctamente";
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
            var Libro = _context.Libros.Find(id);

            if (Libro == null)
            {

                return NotFound();
            }


            return View(Libro);
        }
        //http POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteLibro(int? id)
        {
            var libro = _context.Libros.Find(id);

            if (libro == null) 
            {
                return NotFound();
            }
                _context.Libros.Remove(libro);
                _context.SaveChanges();
                TempData["mensaje"] = "El libro se ha eliminado  correctamente";
                return RedirectToAction("Index");
            
        }
    }
}
