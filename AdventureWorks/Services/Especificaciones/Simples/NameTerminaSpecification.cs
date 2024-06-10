using System.CodeDom;
using AdventureWorks.Models;

namespace AdventureWorks.Services.Especificaciones.Simples
{
    public class NameTerminaSpecification : IProductSpecification
    {
        public string[]? Letras { set; get; }

        public bool IsValid(Product producto)
        {
            if (Letras != null)
            {
                return Letras.Any(x => producto.Name.ToUpper().EndsWith(x));
            }
            else
            {
                return false;
            }
        }
    }
}
