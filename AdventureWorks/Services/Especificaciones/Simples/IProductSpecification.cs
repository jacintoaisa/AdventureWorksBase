using AdventureWorks.Models;

namespace AdventureWorks.Services.Especificaciones.Simples
{
    public interface IProductSpecification
    {
        bool isValid(Product _producto);
    }
}
