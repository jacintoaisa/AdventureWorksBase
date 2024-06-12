using CodeFirst.Models;
using CodeFirst.Services.Repositorio;
using CodeFirst.Services.Specification;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Views.Shared.Components.Libros
{
    public class LibrosViewComponent(IGenericRepositorio<Libro> coleccion) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ILibroSpecification especificacion)
        {
            IEnumerable<Libro> coleccionInicial = await coleccion.DameTodos();
            if (especificacion is not null)
                coleccionInicial = coleccionInicial.Where(especificacion.IsValid);
            return View(coleccionInicial);
        }
    }
}
