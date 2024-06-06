using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Services.Repositorio
{
    public class EFAutorRepositorio : IAutorRepositorio
    {
        private readonly LibreriaContext _context = new();  
        public List<Autor> DameTodos()
        {
            return _context.Autores.AsNoTracking().ToList();

        }

        public Autor? DameUno(int Id)
        {
            return _context.Autores.Find(Id);
        }

        public bool Borrar(int Id)
        {
            if (DameUno(Id) != null)
            {
                _context.Autores.Remove(DameUno(Id));
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Agregar(Autor element)
        {
            if (DameUno(element.Id) != null)
            {

                return false;
            }
            else
            {
                _context.Autores.Add(element);
                _context.SaveChanges();
                return true;
            }
        }

        public void Modificar(int Id, Autor element)
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
