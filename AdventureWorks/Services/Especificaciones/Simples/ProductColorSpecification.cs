using AdventureWorks.Models;
using Microsoft.Build.Logging;

namespace AdventureWorks.Services.Especificaciones.Simples
{
    public class ProductColorSpecification : IProductSpecification
    {
        public string[]? Colores { get; set; }
        public bool IsValid(Product producto)
        {
            if ((producto.Color is not null) && (Colores is not null))
                return Colores.Any(producto.Color.ToUpper().Contains);
            else
                return false;
        }
    }
}
