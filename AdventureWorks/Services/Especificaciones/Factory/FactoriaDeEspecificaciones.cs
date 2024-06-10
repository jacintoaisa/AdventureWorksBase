using AdventureWorks.Models;
using AdventureWorks.Services.Builders;
using AdventureWorks.Services.Especificaciones.Simples;

namespace AdventureWorks.Services.Especificaciones.Factory
{
    public class FactoriaDeEspecificaciones : ISpecificacionFactory
    {
        public IProductSpecification? dameInstancia(EnumeracionEjercicios ejercicio)
        {
            IProductSpecification especificacion = null;
            switch (ejercicio)
            {
                case EnumeracionEjercicios.Ejercicio1:
                    {
                        especificacion = new Ejercicio01Builder();
                        break;
                    }
                case EnumeracionEjercicios.Ejercicio2:
                    {
                        especificacion = new Ejercicio02Builder();
                        break;
                    }
                case EnumeracionEjercicios.Ejercicio3:
                    {
                        especificacion = new Ejercicio03Builder();
                        break;
                    }
            }
            return especificacion;
        }

    }
}
