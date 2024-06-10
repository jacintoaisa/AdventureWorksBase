using AdventureWorks.Models;
using AdventureWorks.Services.Especificaciones.Combinada;
using AdventureWorks.Services.Especificaciones.Factory;
using AdventureWorks.Services.Especificaciones.Simples;

namespace AdventureWorks.Services.Builders
{
    public class Ejercicio03Builder : IProductSpecification, IProductoQuery
    {
        private readonly IProductSpecification _especificacion;

        public Ejercicio03Builder()
        {
            IProductSpecification porInicio = new NameComienzaSpecification()
            {
                Letras = ["A", "B", "C"]
            };
            IProductSpecification porContenido = new NameContieneSpecification()
            {
                Letras = ["A"]
            };
            _especificacion = new AndSpecification()
            {
                Spec1 = porInicio,
                Spec2 = porContenido
            };
        }
        public IEnumerable<Product> DameProductos(IEnumerable<Product> products)
        {
            return products.Where(x => _especificacion.IsValid(x)).OrderBy(x => x.SellStartDate).ThenBy(x => x.Color);
        }
        public bool IsValid(Product producto)
        {
            return _especificacion.IsValid(producto);
        }
    }
}
