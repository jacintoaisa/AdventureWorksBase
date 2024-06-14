using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Models;
using AdventureWorks.Services.Repositorio;
using AdventureWorks.ViewModel;

namespace AdventureWorks.Controllers
{
    public class ProductSubcategoriesController(IGenericRepositorio<ProductSubcategory> _subcategorias,
    IGenericRepositorio<ProductCategory> _categorias) : Controller
    {
        // GET: ProductSubcategories
        public async Task<IActionResult> Index()
        {
            return View(await _subcategorias.DameTodos());
        }

        // GET: ProductSubcategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSubcategory = await _subcategorias.DameUno((int) id);
            if (productSubcategory == null)
            {
                return NotFound();
            }

            return View(productSubcategory);
        }

        // GET: ProductSubcategories/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ProductCategoryId"] = new SelectList(await _categorias.DameTodos(), "ProductCategoryId", "ProductCategoryId");
            return View();
        }

        // POST: ProductSubcategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductSubcategoryId,ProductCategoryId,Name,Rowguid,ModifiedDate")] ProductSubcategory productSubcategory)
        {
            if (ModelState.IsValid)
            {
                await _subcategorias.Agregar(productSubcategory);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductCategoryId"] = new SelectList(await _categorias.DameTodos(), "ProductCategoryId", "ProductCategoryId", productSubcategory.ProductCategoryId);
            return View(productSubcategory);
        }

        // GET: ProductSubcategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductSubcategory? productSubcategorySel = await _subcategorias.DameUno((int)id);
            if (productSubcategorySel == null)
            {
                return NotFound();
            }
            ViewData["ProductCategoryId"] = new SelectList(await _categorias.DameTodos(), "ProductCategoryId", "ProductCategoryId", productSubcategorySel.ProductCategoryId);
            return View(productSubcategorySel);
        }

        // POST: ProductSubcategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductSubcategoryId,ProductCategoryId,Name,Rowguid,ModifiedDate")] ProductSubcategory productSubcategory)
        {
            if (id != productSubcategory.ProductSubcategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _subcategorias.Modificar(productSubcategory.ProductSubcategoryId,productSubcategory);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProductSubcategoryExists(productSubcategory.ProductSubcategoryId))
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
            ViewData["ProductCategoryId"] = new SelectList(await _categorias.DameTodos(), "ProductCategoryId", "ProductCategoryId", productSubcategory.ProductCategoryId);
            return View(productSubcategory);
        }

        // GET: ProductSubcategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductSubcategory? productSubcategory = await _subcategorias.DameUno((int)id);

            if (productSubcategory == null)
            {
                return NotFound();
            }

            return View(productSubcategory);
        }

        // POST: ProductSubcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productSubcategory = await _subcategorias.DameUno(id);
            if (productSubcategory != null)
            {
                await _subcategorias.Borrar(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProductSubcategoryExists(int id)
        {
            var lista = await _subcategorias.DameTodos();
            return lista.Any(e => e.ProductSubcategoryId == id);
        }
    }
}
