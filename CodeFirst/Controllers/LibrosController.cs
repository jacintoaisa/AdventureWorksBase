using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirst.Models;
using CodeFirst.Services.Repositorio;
using CodeFirst.Services.Specification;
using Microsoft.CodeAnalysis.Operations;

namespace CodeFirst.Controllers
{
    public class LibrosController : Controller
    {
        private readonly IGenericRepositorio<Libro> _context;
        private readonly IGenericRepositorio<Autor> _autorContext;

        public LibrosController(IGenericRepositorio<Libro> context, IGenericRepositorio<Autor> autorContext)
        {
            _context = context;
            _autorContext = autorContext;   
        }

        // GET: Libros
        public async Task<IActionResult> Index()
        {
            return View(await _context.DameTodos());
        }

        // GET: Libros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.DameUno((int)id);
            if (libro == null)
            {
                return NotFound();
            }

            return Ok(libro);
        }

        // GET: Libros/Create
        public async Task<IActionResult> Create()
        {
            ViewData["AutorId"] = new SelectList(await _autorContext.DameTodos(), "Id", "NombreCompleto");
            return View();
        }

        // POST: Libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,NumPaginas,AutorId")] Libro libro)
        {

            if (ModelState.IsValid)
            {
                await _context.Agregar(libro);
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        // GET: Libros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.DameUno((int)id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,NumPaginas,AutorId")] Libro libro)
        {
            if (id != libro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Modificar(id,libro);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.Id).Result)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        // GET: Libros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.DameUno((int)id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.DameUno(id);
            if (libro != null)
            {
                await _context.Borrar(id);
            }


            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> LibroExists(int id)
        { 
            var elemento = await _context.DameTodos();
            return (elemento.Any(x=>x.Id == id));
        }

        public bool EsValidoPorPagina(Libro element)
        {
            return (element.NumPaginas > 10);
        }

        public async Task<IActionResult> Tochos()
        {
            var filtrado = await _context.Filtra(x => x.NumPaginas > 2);
            return View("Index",filtrado);
        }

    }
}
