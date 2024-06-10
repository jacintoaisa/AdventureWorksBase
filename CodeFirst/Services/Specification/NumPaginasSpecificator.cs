using CodeFirst.Models;

namespace CodeFirst.Services.Specification
{
    public class NumPaginasSpecificator : ILibroSpecification
    {
        public bool IsValid(Libro element)
        {
            return (element.NumPaginas > 5);
        }
    }
}
