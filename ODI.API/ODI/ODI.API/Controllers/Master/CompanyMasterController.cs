using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODI.DataLayer.Master;
using ODI.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODI.API.Controllers.Master
{
    [Route("api/ODI/[controller]/[action]")]
    [ApiController]
    public class CompanyMasterController : ControllerBase
    {
        private readonly IGenericRepository<CompanyMaster, int> _ICompanyMasterRepository;
        public CompanyMasterController(IGenericRepository<CompanyMaster, int> companyMasterRepo)
        {
            _ICompanyMasterRepository = companyMasterRepo;
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> CreateCompanyMaster(CompanyMaster model)
        {
            var response = await _ICompanyMasterRepository.CreateEntity(model);
            return Ok(response);
        }

        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetCompanyMaster()
        {
            var response = await _ICompanyMasterRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            return Ok(response);
        }

        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> DeleteCompanyMaster(int id)
        {
            var deleteModel = await _ICompanyMasterRepository.GetAllEntities(x => x.Id == id);
            deleteModel.Entities.ToList().ForEach(data =>
            {
                data.IsActive = false;
                data.IsDeleted = true;
            });

            var response = await _ICompanyMasterRepository.DeleteEntity(deleteModel.Entities.FirstOrDefault());
            return Ok(response);
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> UpdateCompanyMaster(CompanyMaster model)
        {
            var deleteModels = await _ICompanyMasterRepository.GetAllEntities(x => x.Id == model.Id);

            deleteModels.Entities.ToList().ForEach(data => {
                data.IsActive = false;
                data.IsDeleted = true;
            });

            
            var createResponse = await _ICompanyMasterRepository.UpdateEntity(deleteModels.Entities.FirstOrDefault());

            return Ok(createResponse);

        }
    }
}
