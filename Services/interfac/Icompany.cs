using CrudSimulacionPruebaTecnica.Models;

namespace CrudSimulacionPruebaTecnica.Services.interfac
{
    public interface Icompany
    {
        //metodo para traer todoas las  empresas
         Task<IEnumerable<Empresas>> GetAllCompanyAsync();
         Task<Empresas> GetByIdCompany(int id);
         Task CreateCompanyAsync(Empresas empresas);
         Task UpdateCompanyAsync(Empresas empresas);
         Task DeleteCompanyAsync(int id);
    }
}
