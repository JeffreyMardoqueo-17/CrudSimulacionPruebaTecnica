using CrudSimulacionPruebaTecnica.Data;
using CrudSimulacionPruebaTecnica.Models;
using CrudSimulacionPruebaTecnica.Services.interfac;
using Microsoft.EntityFrameworkCore;

namespace CrudSimulacionPruebaTecnica.Services.service
{
    public class CompanyService: Icompany
    {
        //inyecto el contexto al constructor 
        private readonly AplicationDBContext _context;
        public CompanyService(AplicationDBContext aplicationDB)
        {
            _context = aplicationDB;
        }
        //implemento el metodo de la interfaz 
        public async Task<IEnumerable<Empresas>> GetAllCompanyAsync()
        {
            return await _context.Empresas.ToListAsync(); //retornara la lista de empresas
        }
        public async Task<Empresas> GetByIdCompany (int id)
        {
           var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
                throw new KeyNotFoundException($"No se encontro ninguna emrpresa con el id {id}");
            return empresa;
        }
        public async Task CreateCompanyAsync (Empresas empresa)
        {
            if(empresa == null)
                throw new ArgumentNullException(nameof(empresa), "El producto no puede ser nulo");

            
            await _context.Empresas.AddAsync(empresa);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCompanyAsync(Empresas empresas)
        {
            var empresaExiste = await GetByIdCompany(empresas.Id);
            if (empresaExiste == null)
                throw new KeyNotFoundException("La empresa no existe por eso no se puede modificar");

            //si tiene un valor, edito prpieda dpor propiedad
            empresaExiste.Name = empresas.Name;
            empresaExiste.Direccion = empresas.Direccion;
            empresaExiste.Telefono = empresas.Telefono;

            await _context.SaveChangesAsync();
        }
        public async Task DeleteCompanyAsync(int id)
        {
            var empresaExiste = await GetByIdCompany(id);
            if (empresaExiste == null)
                throw new KeyNotFoundException("La empresa no existe por eso no se puede modificar");
            _context.Empresas.Remove(empresaExiste);
            await _context.SaveChangesAsync();
        }
    }
}
