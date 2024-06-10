using AdventureWorks.Services.Especificaciones.Simples;

namespace AdventureWorks.Services.Especificaciones.Factory
{
    public interface ISpecificacionFactory
    {
        IProductSpecification? DameInstancia(EnumeracionEjercicios ejercicio);

    }
}
