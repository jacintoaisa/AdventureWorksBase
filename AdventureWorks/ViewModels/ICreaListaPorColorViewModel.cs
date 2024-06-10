namespace AdventureWorks.ViewModels
{
    public interface ICreaListaPorColorViewModel
    {
        Task<List<ProductoPorColorViewModel>> dameTodosLosColores();
    }
}
