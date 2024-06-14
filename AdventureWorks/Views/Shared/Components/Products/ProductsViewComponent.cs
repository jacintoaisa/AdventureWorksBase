using System.Drawing;
using AdventureWorks.Models;
using AdventureWorks.Services.Especificaciones.Simples;
using AdventureWorks.Services.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.Views.Shared.Components.Products
{
    public class ProductsViewComponent (IGenericRepositorio<Product> _products,
        IGenericRepositorio<ProductSubcategory> _subcategorias,
        IGenericRepositorio<ProductCategory> _categorias): ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IProductSpecification especificacion)
        {
            IEnumerable<Product> coleccionInicial = await _products.DameTodos();
            coleccionInicial = coleccionInicial.Where(especificacion.IsValid);
            List<ProductsViewModel> miColeccion = [];
            foreach (var _producto in coleccionInicial)
            {
                if (_producto.ProductSubcategoryId != null)
                {
                    ProductSubcategory? subcat = await _subcategorias.DameUno((int)_producto.ProductSubcategoryId);
                    if (subcat != null)
                    {
                        ProductCategory? cat = await _categorias.DameUno((int)subcat.ProductCategoryId);
                        if (cat != null)
                        {
                            ProductsViewModel pvm = new ProductsViewModel()
                            {
                                Color = _producto.Color,
                                ProductID = _producto.ProductId,
                                Name = _producto.Name,
                                MakeFlag = _producto.MakeFlag,
                                ProductNumber = _producto.ProductNumber,
                                FinishedGoodsFlag = _producto.FinishedGoodsFlag,
                                ProductSubcategoryID = (int)_producto.ProductSubcategoryId,
                                NombreSubcategoria = subcat.Name,
                                ProductCategoryId = cat.ProductCategoryId,
                                NombreCategoria = cat.Name
                            };
                            miColeccion.Add(pvm);
                        }
                    }
                }
            }

            return View(miColeccion);
        }
    }


}
