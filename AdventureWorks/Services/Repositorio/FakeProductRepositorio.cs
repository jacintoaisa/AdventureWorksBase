using AdventureWorks.Models;

namespace AdventureWorks.Services.Repositorio
{
    public class FakeProductRepositorio : IProductoRepositorio
    {
        private readonly List<Product> listaProductos = [];

        public FakeProductRepositorio()
        {
            Product miProducto = new()
            {
                ProductId = 1,
                Name = "Producto Fake01",
                Class = "Clase Fake",
                Color = "red",
                DaysToManufacture = 5,
                FinishedGoodsFlag = true,
                ListPrice = 100
            };
            listaProductos.Add(miProducto);
            miProducto = new()
            {
                ProductId = 2,
                Name = "Producto Fake02",
                Class = "Clase Fake",
                Color = "red",
                DaysToManufacture = 4,
                FinishedGoodsFlag = false,
                ListPrice = 100
            };
            listaProductos.Add(miProducto);
            miProducto = new()
            {
                ProductId = 3,
                Name = "Producto Fake03",
                Class = "Clase Fake",
                Color = "blue",
                DaysToManufacture = 4,
                FinishedGoodsFlag = false,
                ListPrice = 100
            };
            listaProductos.Add(miProducto);
            miProducto = new()
            {
                ProductId = 4,
                Name = "Producto Fake04",
                Class = "Clase Fake",
                Color = "blue",
                DaysToManufacture = 4,
                FinishedGoodsFlag = false,
                ListPrice = 100
            };
            listaProductos.Add(miProducto);
        }
        public async Task<List<Product>> DameTodos()
        {
            return await Task.Run(()=>listaProductos);
        }

        public async Task<Product?> DameUno(int Id)
        {
            return await Task.Run(()=>this.listaProductos.Find(x=>x.ProductId==Id));
        }

        public async Task<bool> BorrarProducto(int Id)
        {
            Product? productoEncontrado = await DameUno(Id);
            if (productoEncontrado != null)
            {
                listaProductos.Remove(productoEncontrado);
                return true;
            }

            return false;
        }

        public async Task<bool> Agregar(Product product)
        { 
            this.listaProductos.Add(product);
            return await Task.Run(()=>true);
        }

        public async Task<bool> Modificar(int Id, Product product)
        {
            await BorrarProducto(Id);
            await Agregar(product);
            return await Task.Run(() => true);
        }
    }
}
