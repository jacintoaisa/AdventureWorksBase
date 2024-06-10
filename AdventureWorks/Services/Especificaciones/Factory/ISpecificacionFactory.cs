using AdventureWorks.Services.Especificaciones.Simples;

namespace AdventureWorks.Services.Especificaciones.Factory
{
    public interface ISpecificacionFactory
    {
        IProductSpecification? dameInstancia(EnumeracionEjercicios ejercicio);

    }
}
