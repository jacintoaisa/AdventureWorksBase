using AdventureWorks.Models;
using AdventureWorks.Services.Especificaciones.Simples;

namespace AdventureWorks.Services.Especificaciones.Combinada
{
    public class NotSpecification : IProductSpecification
    {
        public IProductSpecification? Especificacion { get; set; }

        public bool IsValid(Product producto)
        {
            if (Especificacion == null)
            {
                return false;
            }
            else
            {
                return !Especificacion.IsValid(producto);
            }
        }
    }
}
