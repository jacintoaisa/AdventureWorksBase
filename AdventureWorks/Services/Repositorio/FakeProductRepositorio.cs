using AdventureWorks.Models;

namespace AdventureWorks.Services.Repositorio
{
    public class FakeProductRepositorio : IProductoRepositorio
    {
        private List<Product> listaProductos = new();

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
        public List<Product> DameTodos()
        {
            return this.listaProductos;
        }

        public Product? DameUno(int Id)
        {
            return this.listaProductos.FirstOrDefault(x=>x.ProductId==Id);
        }

        public bool BorrarProducto(int Id)
        {
            return listaProductos.Remove(DameUno(Id));
        }

        public bool Agregar(Product product)
        {
            this.listaProductos.Add(product);
            return true;
        }

        public void Modificar(int Id, Product product)
        {
            BorrarProducto(Id);
            Agregar(product);
        }
    }
}
