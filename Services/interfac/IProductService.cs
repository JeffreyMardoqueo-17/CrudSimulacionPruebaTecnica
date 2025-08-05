using CrudSimulacionPruebaTecnica.Models;

namespace CrudSimulacionPruebaTecnica.Services.interfac
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<Product> GetByIdProductAsync(int id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
