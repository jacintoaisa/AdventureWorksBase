using AdventureWorks.Models;

namespace AdventureWorks.Services.Especificaciones.Factory
{
    public interface IProductoQuery
    {
        IEnumerable<Product> DameProductos(IEnumerable<Product> products);
    }
}
