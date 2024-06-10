using System.Linq.Expressions;
using CodeFirst.Models;

namespace CodeFirst.Services.Repositorio
{
    public interface IGenericRepositorio<T> where T : class
    {
        Task<List<T>> DameTodos();
        T? DameUno(int Id);
        Task<bool> Borrar(int Id);
        bool Agregar(T element);
        void Modificar(int Id, T element);
        IEnumerable<T> Filtra(Expression<Func<T, bool>> predicado);
    }
}
