using CodeFirst.Models;

namespace CodeFirst.Services.Repositorio
{
    public class FakeAutorRepositorio : IAutorRepositorio
    {
        private List<Autor> listaProductos = new();

        public FakeAutorRepositorio()
        {
            Autor miProducto = new()
            {
                Id = 1,
                NombreCompleto = "Julio Verne"
            };
            listaProductos.Add(miProducto);
            miProducto = new()
            {
                Id = 2,
                NombreCompleto = "Miguel de Cervantes"
            };
            listaProductos.Add(miProducto);
        }
        public List<Autor> DameTodos()
        {
            return this.listaProductos;
        }

        public Autor? DameUno(int Id)
        {
            return this.listaProductos.FirstOrDefault(x=>x.Id==Id);
        }

        public bool Borrar(int Id)
        {
            return listaProductos.Remove(DameUno(Id));
        }

        public bool Agregar(Autor element)
        {
            this.listaProductos.Add(element);
            return true;
        }

        public void Modificar(int Id, Autor product)
        {
            Borrar(Id);
            Agregar(product);
        }
    }
}
