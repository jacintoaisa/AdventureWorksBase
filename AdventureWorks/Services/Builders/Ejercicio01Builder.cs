using AdventureWorks.Models;
using AdventureWorks.Services.Especificaciones.Combinada;
using AdventureWorks.Services.Especificaciones.Factory;
using AdventureWorks.Services.Especificaciones.Simples;

namespace AdventureWorks.Services.Builders
{
    public class Ejercicio01Builder : IProductSpecification, IProductoQuery
    {
        private IProductSpecification _especificacion;
        public Ejercicio01Builder()
        {
            IProductSpecification porColor = new ProductColorSpecification()
            {
                Colores = ["RED", "GREEN"]
            };
            IProductSpecification porDinero = new ListPriceSpecification()
            {
                Price = 1
            };
            _especificacion = new AndSpecification()
            {
                Spec1 = porColor,
                Spec2 = porDinero
            };
        }

        public IEnumerable<Product> DameProductos(IEnumerable<Product> products)
        {
            return products.Where(IsValid).OrderBy(x => x.SafetyStockLevel);
        }

        public bool IsValid(Product producto)
        {
            return _especificacion.IsValid(producto);
        }
    }
}
