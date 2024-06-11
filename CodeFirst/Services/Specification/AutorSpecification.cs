using CodeFirst.Models;

namespace CodeFirst.Services.Specification
{
    public class AutorSpecification (int AutorId): ILibroSpecification
    {
        public bool IsValid(Libro element)
        {
            return element.AutorId == AutorId ;
        }
    }
}
