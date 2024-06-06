using CodeFirst.Models;

namespace CodeFirst.Services.Repositorio
{
    public interface ILibroRepositorio
    {
        List<Libro> DameTodos();
        Libro? DameUno(int Id);
        bool Borrar(int Id);
        bool Agregar(Libro element);
        void Modificar(int Id, Libro element);


    }
}
