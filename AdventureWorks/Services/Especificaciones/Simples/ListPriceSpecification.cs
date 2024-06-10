using AdventureWorks.Models;

namespace AdventureWorks.Services.Especificaciones.Simples
{
    public class ListPriceSpecification : IProductSpecification
    {
        public int Price { get; set; }
        public bool isValid(Product _producto)
        {
            if (_producto is not null)
                return _producto.ListPrice >= Price;
            else
                return false;
        }
    }
}
