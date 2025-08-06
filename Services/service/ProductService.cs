using CrudSimulacionPruebaTecnica.Data;
using CrudSimulacionPruebaTecnica.Models;
using CrudSimulacionPruebaTecnica.Services.interfac;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

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
            var product = await _context.Product.FindAsync(id);
            if (product == null)
                throw new KeyNotFoundException($"No se encontro ningun producto con este id {id}");
            return product;
        }
        public async Task CreateProductAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "El producto no puede ser nulo");

            product.CreateAt = DateTime.Now;//se guardara la fecha actual
            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateProductAsync(Product product)
        {
            var existeProducto = await GetByIdProductAsync(product.Id);
            if (existeProducto == null)
                throw new KeyNotFoundException($"Este producto no existe");
            //actualizo propiedad por propiedad asi no se actualiza todo el producto o las propiedades nsesearias
            existeProducto.Name = product.Name;
            existeProducto.Description = product.Description;
            existeProducto.Price = product.Price;
            existeProducto.Stock = product.Stock;

            await _context.SaveChangesAsync();
        }
        public async Task DeleteProductAsync(int id)
        {
            var product = await GetByIdProductAsync(id);
            if (product == null)
                throw new KeyNotFoundException($"Este producto no existe");

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }

    }
}
