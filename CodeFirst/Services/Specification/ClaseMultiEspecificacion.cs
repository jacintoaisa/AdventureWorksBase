using CodeFirst.Models;

namespace CodeFirst.Services.Specification
{
    public class ClaseMultiEspecificacion : ILibroSpecification
    {
        private List<ILibroSpecification> coleccion = [];

        public void Add(ILibroSpecification elemento)
        {
            coleccion.Add(elemento);
        }
        public bool IsValid(Libro element)
        {
            foreach (var condicion in coleccion)
            {
                if (!condicion.IsValid(element))
                    return false;
            }
            return true;
        }
    }
}
