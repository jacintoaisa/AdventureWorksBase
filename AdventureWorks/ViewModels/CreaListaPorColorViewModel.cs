
using AdventureWorks.Models;

namespace AdventureWorks.ViewModels
{
    public class CreaListaPorColorViewModel(AdventureWorks2016Context context)
        : ICreaListaPorColorViewModel
    {

        public async Task<List<ProductoPorColorViewModel>> dameTodosLosColores()
        {
            var ProductosDistintos = from p in context.Products group(p) by p.Color into g
                select g;

            List<ProductoPorColorViewModel> coleccionADevolver = [];
            foreach (var _colorDistinto in ProductosDistintos)
            {
                ProductoPorColorViewModel ElementoAPoner = 
                    new() { Color = _colorDistinto.Key , VentasDeProducto =
                            [.. new ProductoPorColor01(context).DamePorColor(_colorDistinto.Key)]
                    };
                coleccionADevolver.Add(ElementoAPoner);
            }
            return await Task.Run(()=>coleccionADevolver);
        }
    }
}
