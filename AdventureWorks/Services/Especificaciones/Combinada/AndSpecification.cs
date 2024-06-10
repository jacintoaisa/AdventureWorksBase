using AdventureWorks.Models;
using AdventureWorks.Services.Especificaciones.Simples;

namespace AdventureWorks.Services.Especificaciones.Combinada
{
    public class AndSpecification : IProductSpecification
    {
        public IProductSpecification? Spec1 { get; set; }
        public IProductSpecification? Spec2 { get; set; }

        public bool IsValid(Product producto)
        {
            if (Spec1 != null && Spec2 != null)
            {
                return Spec1.IsValid(producto) && Spec2.IsValid(producto);
            }

            return false;
        }
    }
}
