using CodeFirst.Models;
using CodeFirst.Services.Repositorio;
using CodeFirst.Services.Specification;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Views.Shared.Components
{
    public class LibrosViewComponent (IGenericRepositorio<Libro> coleccion): ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int AutorId)
        {
            var items = await coleccion.DameTodos();
            ILibroSpecification especificacion = new AutorSpecification(AutorId);
            var itemsFiltrados = items.Where(especificacion.IsValid);
            return View(itemsFiltrados);
        }
    }
}
