using AdventureWorks.Models;
using Microsoft.Data.SqlClient.DataClassification;

namespace AdventureWorks.Services.Repositorio
{
    public interface IProductoRepositorio
    {
        Task<List<Product>> DameTodos();
        Task<Product?> DameUno(int Id);
        Task<bool> BorrarProducto(int Id);
        Task<bool> Agregar(Product product);
        Task<bool> Modificar(int Id, Product product);


    }
}
