using AdventureWorks.Models;

namespace AdventureWorks.Services.Especificaciones.Simples
{
    public class NameComienzaSpecification : IProductSpecification
    {
        public string[]? Letras { set; get; }

        public bool IsValid(Product producto)
        {
            if (Letras is not null)
                return Letras.Any(x => producto.Name.Contains(x,StringComparison.InvariantCultureIgnoreCase));
            else
            {
                return false;
            }
        }
    }
}
