using AdventureWorks.Models;
using AdventureWorks.Services.Especificaciones.Combinada;
using AdventureWorks.Services.Especificaciones.Factory;
using AdventureWorks.Services.Especificaciones.Simples;

namespace AdventureWorks.Services.Builders
{
    public class Ejercicio02Builder : IProductSpecification, IProductoQuery
    {
        private IProductSpecification especificacion;

        public Ejercicio02Builder()
        {
            IProductSpecification PorColor = new ProductColorSpecification()
            {
                Colores = ["RED"]
            };
            IProductSpecification PorTerminacion = new NameTerminaSpecification()
            {
                Letras = ["A", "E", "I", "O", "U", "X"]
            };
            IProductSpecification NoPorTerminacion = new NotSpecification()
            {
                Especificacion = PorTerminacion
            };
            IProductSpecification PorSubCategoria = new SubCategoriaSpecificacion()
            {
                Subcategorias = [2]
            };
            IProductSpecification NotPorSubCategoria = new NotSpecification()
            {
                Especificacion = PorSubCategoria
            };
            IProductSpecification And01 = new AndSpecification()
            {
                Spec1 = PorColor,
                Spec2 = NoPorTerminacion
            };
            especificacion = new AndSpecification()
            {
                Spec1 = And01,
                Spec2 = NotPorSubCategoria
            };
        }

        public IEnumerable<Product> DameProductos(IEnumerable<Product> products)
        {
            return products.Where(x => especificacion.IsValid(x)).OrderBy(x => x.Name);
        }
        public bool IsValid(Product _producto)
        {
            return especificacion.IsValid(_producto);
        }
    }
}

