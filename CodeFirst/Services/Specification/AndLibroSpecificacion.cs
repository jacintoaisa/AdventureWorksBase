using CodeFirst.Models;

namespace CodeFirst.Services.Specification
{
    public class AndLibroSpecificacion 
        (ILibroSpecification especificacion01, 
            ILibroSpecification especificacion02): ILibroSpecification
    {
        public bool IsValid(Libro element)
        {
            return especificacion01.IsValid(element) && especificacion02.IsValid(element);
        }
    }
}
