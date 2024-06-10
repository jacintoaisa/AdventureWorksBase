using System.CodeDom;
using AdventureWorks.Models;

namespace AdventureWorks.Services.Especificaciones.Simples
{
    public class NameTerminaSpecification : IProductSpecification
    {
        public string[]? letras { set; get; }

        public bool isValid(Product _producto)
        {
            if (letras != null)
            {
                return letras.Any(x => _producto.Name.ToUpper().EndsWith(x));
            }
            else
            {
                return false;
            }
        }
    }
}
