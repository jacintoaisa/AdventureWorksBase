using CodeFirst.Models;

namespace CodeFirst.Services.Repositorio
{
    public interface IAutorRepositorio
    {
        List<Autor> DameTodos();
        Autor? DameUno(int Id);
        bool Borrar(int Id);
        bool Agregar(Autor element);
        void Modificar(int Id, Autor element);


    }
}
