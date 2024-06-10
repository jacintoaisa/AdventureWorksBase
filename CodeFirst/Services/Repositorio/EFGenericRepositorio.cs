using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CodeFirst.Services.Repositorio
{
    public class EFGenericRepositorio<T> : IGenericRepositorio<T> where T : class
    {
        private readonly LibreriaContext _context = new();  
        public async Task<List<T>> DameTodos()
        {
            return await _context.Set<T>().ToListAsync();
        }


        

        public T? DameUno(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public async Task<bool> Borrar(int Id)
        {
            var elemento = DameUno(Id);
            _context.Set<T>().Remove(elemento);
            _context.SaveChanges();
            //return Task.FromResult(true);
            return true;
        }

        public bool Agregar(T element)
        {
            _context.Set<T>().Add(element);
            _context.SaveChanges();
            return true;
        }

        public void Modificar(int Id, T element)
        {
            _context.Entry(element).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<T> Filtra(Expression<Func<T, bool>> predicado)
        {
            return _context.Set<T>().Where<T>(predicado).ToList();
        }


    }
}
