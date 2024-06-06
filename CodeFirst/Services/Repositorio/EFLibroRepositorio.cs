using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Services.Repositorio
{
    public class EFLibroRepositorio : ILibroRepositorio
    {
        private readonly LibreriaContext _context = new();
        public List<Libro> DameTodos()
        {
            return _context.Libros.AsNoTracking().ToList();

        }

        public Libro? DameUno(int Id)
        {
            return _context.Libros.Find(Id);
        }

        public bool Borrar(int Id)
        {
            if (DameUno(Id) != null)
            {
                _context.Libros.Remove(DameUno(Id));
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Agregar(Libro element)
        {
            if (DameUno(element.Id) != null)
            {

                return false;
            }
            else
            {
                _context.Libros.Add(element);
                _context.SaveChanges();
                return true;
            }
        }

        public void Modificar(int Id, Libro element)
        {
            var recupera = DameUno(Id);
            if (recupera != null)
            {
                Borrar(Id);
            }
            Agregar(element);
        }
    }
}
