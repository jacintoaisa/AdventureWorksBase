using CodeFirst.Models;

namespace CodeFirst.Services.Specification
{
    public interface ILibroSpecification
    {
        bool IsValid(Libro element);
    }
}
