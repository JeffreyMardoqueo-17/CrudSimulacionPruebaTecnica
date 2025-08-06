using CrudSimulacionPruebaTecnica.Models;
using CrudSimulacionPruebaTecnica.Services.interfac;
using CrudSimulacionPruebaTecnica.Services.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrudSimulacionPruebaTecnica.Controllers
{
    public class CompanyController : Controller
    {
        private readonly CompanyService _companyService;
        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: CompanyController
        public async Task<ActionResult> Index()
        {
            var empresas = await _companyService.GetAllCompanyAsync(); //llamo a todas las empreas 
            return View(empresas);//las retorno en la vistas
        }

        // GET: CompanyController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var empresa = await _companyService.GetByIdCompany(id);
                return View(empresa);
            }catch(KeyNotFoundException ex)
            {
                return View(ex.Message);
            }
        }

        // GET: CompanyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Empresas empresas)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(empresas);

                await _companyService.CreateCompanyAsync(empresas);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: CompanyController/Edit/5 ------> este  lo que hace es que tar e los datos que se mostraran antes de editarse para por el get
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var empresa = await _companyService.GetByIdCompany(id);
                return View(empresa);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: CompanyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Empresas empresas)
        {
            if (!ModelState.IsValid)
                return View(empresas);

            try
            {
            await _companyService.UpdateCompanyAsync(empresas);
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: CompanyController/Delete/5
        public async Task< ActionResult> Delete(int id)
        {
            try
            {
                var empresa = await _companyService.GetByIdCompany(id);
                return View(empresa);
            }catch(KeyNotFoundException ex)
            {
                return NotFound(ex);
            }
        }

        // POST: CompanyController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _companyService.DeleteCompanyAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
