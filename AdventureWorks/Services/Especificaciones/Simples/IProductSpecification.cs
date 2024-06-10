using AdventureWorks.Models;

namespace AdventureWorks.Services.Especificaciones.Simples
{
    public interface IProductSpecification
    {
        bool IsValid(Product producto);
    }
}
