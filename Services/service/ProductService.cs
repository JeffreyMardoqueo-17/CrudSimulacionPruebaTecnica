using CrudSimulacionPruebaTecnica.Data;
using CrudSimulacionPruebaTecnica.Models;
using CrudSimulacionPruebaTecnica.Services.interfac;
using Microsoft.EntityFrameworkCore;

namespace CrudSimulacionPruebaTecnica.Services.service
{
    public class ProductService : IProductService
    {
       private readonly AplicationDBContext _context;
        public ProductService(AplicationDBContext aplicationDBContext)
        {
            _context = aplicationDBContext;
        }
        //metodod para obtener tdos
        public async Task<IEnumerable<Product>> GetAllProductAsync() {
            return await _context.Product.ToListAsync();
        }
        public async Task<Product> GetByIdProductAsync(int id)
        {
            return await _context.Product.FindAsync(id);
        }
        public async Task CreateProductAsync(Product product)
        {
            _context.Product.Add(product); //AGREGO EL PRODUCTO
            await _context.SaveChangesAsync();//LO GUARDO 
        }
        public async Task UpdateProductAsync(Product product)
        {
            _context.Product.Update(product); //acutalizo el producto
            await _context.SaveChangesAsync();
        }
        public async Task DeleteProductAsync(int id)
        {
            var product = await GetByIdProductAsync(id);
            if(product != null)
            {
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
