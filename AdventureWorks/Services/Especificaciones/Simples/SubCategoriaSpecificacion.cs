using AdventureWorks.Models;

namespace AdventureWorks.Services.Especificaciones.Simples
{
    public class SubCategoriaSpecificacion : IProductSpecification
    {
        public int[]? Subcategorias { get; set; }
        public bool IsValid(Product _producto)
        {
            if (Subcategorias != null)
            {
                return Subcategorias.Any(x => x == _producto.ProductSubcategoryId);
            }
            else
            {
                return false;
            }
        }
    }
}
