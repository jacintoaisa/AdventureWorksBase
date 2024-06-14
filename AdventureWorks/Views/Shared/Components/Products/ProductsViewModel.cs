namespace AdventureWorks.Views.Shared.Components.Products
{
    public class ProductsViewModel
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string Color { get; set; }
        public int ProductSubcategoryID { get; set; }
        public string NombreSubcategoria { get; set; }
        public int ProductCategoryId { get; set; }
        public string NombreCategoria { get; set; }
    }
}
