using CrudSimulacionPruebaTecnica.Models;

namespace CrudSimulacionPruebaTecnica.Services.interfac
{
    interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<Product> GetByIdProductAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
