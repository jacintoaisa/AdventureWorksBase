using AdventureWorks.Models;
using AdventureWorks.Services.Especificaciones.Simples;

namespace AdventureWorks.Services.Especificaciones.Combinada
{
    public class OrSpecification : IProductSpecification
    {
        public IProductSpecification? Spec1 { get; set; }
        public IProductSpecification? Spec2 { get; set; }

        public bool isValid(Product _producto)
        {
            if (Spec1 != null && Spec2 != null)
            {
                return Spec1.isValid(_producto) || Spec2.isValid(_producto);
            }
            else
            {
                return false;
            }
        }
    }
}
