﻿using AdventureWorks.Models;

namespace AdventureWorks.Services.Especificaciones.Simples
{
    public class NameContieneSpecification : IProductSpecification
    {
        public string[]? letras { set; get; }

        public bool isValid(Product _producto)
        {
            if (letras == null)
                return false;
            else
                return letras.Any(x => _producto.Name.ToUpper().Contains(x));
        }
    }
}
