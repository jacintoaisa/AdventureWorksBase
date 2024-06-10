using AdventureWorks.Models;

namespace AdventureWorks.Services.Especificaciones.Simples
{
    public class NameComienzaSpecification : IProductSpecification
    {
        public string[]? letras { set; get; }

        public bool isValid(Product _producto)
        {
            if (letras is not null)
                return letras.Any(x => _producto.Name.ToUpper().StartsWith(x));
            else
            {
                return false;
            }
        }
    }
}
