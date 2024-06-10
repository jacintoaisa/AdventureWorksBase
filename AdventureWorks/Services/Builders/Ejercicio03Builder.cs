using AdventureWorks.Models;
using AdventureWorks.Services.Especificaciones.Combinada;
using AdventureWorks.Services.Especificaciones.Factory;
using AdventureWorks.Services.Especificaciones.Simples;

namespace AdventureWorks.Services.Builders
{
    public class Ejercicio03Builder : IProductSpecification, IProductoQuery
    {
        private IProductSpecification especificacion;

        public Ejercicio03Builder()
        {
            IProductSpecification PorInicio = new NameComienzaSpecification()
            {
                letras = ["A", "B", "C"]
            };
            IProductSpecification PorContenido = new NameContieneSpecification()
            {
                letras = ["A"]
            };
            especificacion = new AndSpecification()
            {
                Spec1 = PorInicio,
                Spec2 = PorContenido
            };
        }
        public IEnumerable<Product> dameProductos(IEnumerable<Product> products)
        {
            return products.Where(x => especificacion.isValid(x)).OrderBy(x => x.SellStartDate).ThenBy(x => x.Color);
        }
        public bool isValid(Product _producto)
        {
            return especificacion.isValid(_producto);
        }
    }
}
