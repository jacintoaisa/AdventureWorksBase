using AdventureWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Services.Repositorio
{
    public class EFProductoRepositorio : IProductoRepositorio
    {
        private readonly AdventureWorks2016Context _context = new();  
        public async Task<List<Product>> DameTodos()
        {
            return await _context.Products.ToListAsync();

        }

        public async Task<Product?> DameUno(int Id)
        {
            return await _context.Products.FindAsync(Id);
        }

        public async Task<bool> BorrarProducto(int Id)
        {
            var producto = await DameUno(Id);
            if (producto != null)
            {
                _context.Products.Remove(producto);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Agregar(Product product)
        {
            if (await DameUno(product.ProductId) != null)
            {

                return false;
            }
            else
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> Modificar(int Id, Product product)
        {
            var recupera = await DameUno(Id);
            if (recupera != null)
            {
                await BorrarProducto(Id);
            }
            await Agregar(product);
            return await Task.Run(() => true);
        }
    }
}
