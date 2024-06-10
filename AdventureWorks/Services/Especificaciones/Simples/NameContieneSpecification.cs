using AdventureWorks.Models;

namespace AdventureWorks.Services.Especificaciones.Simples
{
    public class NameContieneSpecification : IProductSpecification
    {
        public string[]? Letras { set; get; }

        public bool IsValid(Product producto)
        {
            if (Letras == null)
                return false;
            else
                return Letras.Any(x => producto.Name.Contains(x,StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
