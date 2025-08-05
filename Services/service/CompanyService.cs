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
        public async Task<IEnumerable<Empresas>> GetAllProductAsync()
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
    }
}
