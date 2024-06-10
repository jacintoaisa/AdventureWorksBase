using AdventureWorks.Models;
using AdventureWorks.Services.Especificaciones.Simples;

namespace AdventureWorks.Services.Especificaciones.Combinada
{
    public class NotSpecification : IProductSpecification
    {
        public IProductSpecification? especificacion { get; set; }

        public bool isValid(Product _producto)
        {
            if (especificacion == null)
            {
                return false;
            }
            else
            {
                return !especificacion.isValid(_producto);
            }
        }
    }
}
