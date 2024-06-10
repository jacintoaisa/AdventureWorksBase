using AdventureWorks.Models;

namespace AdventureWorks.Services.Especificaciones.Factory
{
    public interface IProductoQuery
    {
        IEnumerable<Product> dameProductos(IEnumerable<Product> products);
    }
}
