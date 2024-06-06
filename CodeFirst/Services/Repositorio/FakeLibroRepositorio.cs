using CodeFirst.Models;

namespace CodeFirst.Services.Repositorio
{
    public class FakeLibroRepositorio : ILibroRepositorio
    {
        private List<Libro> listaProductos = new();

        public FakeLibroRepositorio()
        {
            Libro miProducto = new()
            {
                Id = 1,
                NumPaginas = 189,
                Titulo = "Viaje a la Luna",
                AutorId = 1
            };
            listaProductos.Add(miProducto);
            miProducto = new Libro
            {
                Id = 2,
                NumPaginas = 678,
                Titulo = "Robinson Crusoe",
                AutorId = 1
            };
            listaProductos.Add(miProducto);
            miProducto = new()
            {
                Id = 3,
                NumPaginas = 123,
                Titulo = "El Quijote",
                AutorId = 2
            };
            listaProductos.Add(miProducto);
            miProducto = new()
            {
                Id = 4,
                NumPaginas = 234,
                Titulo ="Rinconete y Cortadillo",
                AutorId = 2
            };
            listaProductos.Add(miProducto);
        }
        public List<Libro> DameTodos()
        {
            return this.listaProductos;
        }

        public Libro? DameUno(int Id)
        {
            return this.listaProductos.FirstOrDefault(x=>x.Id==Id);
        }

        public bool Borrar(int Id)
        {
            return listaProductos.Remove(DameUno(Id));
        }

        public bool Agregar(Libro element)
        {
            this.listaProductos.Add(element);
            return true;
        }

        public void Modificar(int Id, Libro product)
        {
            Borrar(Id);
            Agregar(product);
        }
    }
}
