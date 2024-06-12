using AdventureWorks.Models;
using AdventureWorks.Services.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.Views.Shared.Components.Products
{
    public class ProductsViewComponent (IProductoRepositorio repositorio): ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string color)
        {
            IEnumerable<Product> coleccionInicial = await repositorio.DameTodos();
            coleccionInicial = coleccionInicial.Where(x=>x.Color != null && x.Color.ToUpper() == color.ToUpper());
            return View(coleccionInicial);
        }
    }


}
