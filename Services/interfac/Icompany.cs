using CrudSimulacionPruebaTecnica.Models;

namespace CrudSimulacionPruebaTecnica.Services.interfac
{
    public interface Icompany
    {
        //metodo para traer todoas las  empresas
         Task<IEnumerable<Empresas>> GetAllCompanyAsync();
         Task<Empresas> GetByIdCompany(int id);
         Task CreateCompanyAsync(Empresas empresas);
         Task EditCompanyAsync(Empresas empresas);
         Task DeleteCompanyAsync(int id);
    }
}
