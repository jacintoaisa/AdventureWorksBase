using AdventureWorks.Models;

namespace AdventureWorks.Services.Especificaciones.Simples
{
    public class ListPriceSpecification : IProductSpecification
    {
        public int Price { get; set; }
        public bool IsValid(Product producto)
        {
            if (producto is not null)
                return producto.ListPrice >= Price;
            else
                return false;
        }
    }
}
