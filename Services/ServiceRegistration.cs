using CrudSimulacionPruebaTecnica.Services;
using CrudSimulacionPruebaTecnica.Services.interfac;
using CrudSimulacionPruebaTecnica.Services.service;

namespace CrudSimulacionPruebaTecnica.Services
{
    public static class ServiceRegistration
    {
        public static void AddAplicationServices(this IServiceCollection services)
        {
            //aqui voy a registrar todos los servicios
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
