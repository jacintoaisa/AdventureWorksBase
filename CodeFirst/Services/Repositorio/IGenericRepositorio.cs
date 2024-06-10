using System.Linq.Expressions;
using CodeFirst.Models;

namespace CodeFirst.Services.Repositorio
{
    public interface IGenericRepositorio<T> where T : class
    {
        Task<List<T>> DameTodos();
        Task<T?> DameUno(int Id);
        Task<bool> Borrar(int Id);
        Task<bool> Agregar(T element);
        Task<bool> Modificar(int Id, T element);
        Task<IEnumerable<T>> Filtra(Expression<Func<T, bool>> predicado);
    }
}
