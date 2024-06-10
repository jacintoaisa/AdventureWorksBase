using AdventureWorks.Models;

namespace AdventureWorks.Services.Especificaciones.Simples
{
    public class SubCategoriaSpecificacion : IProductSpecification
    {
        public int[]? subcategorias { get; set; }
        public bool isValid(Product _producto)
        {
            if (subcategorias != null)
            {
                return subcategorias.Any(x => x == _producto.ProductSubcategoryId);
            }
            else
            {
                return false;
            }
        }
    }
}
