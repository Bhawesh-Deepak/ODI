using Microsoft.AspNetCore.Cors;
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
   
    public class ClaimHeadMasterController : ControllerBase
    {
        private readonly IGenericRepository<ClaimHeadMaster, int> _IClaimHeadMasterRepository;
        public ClaimHeadMasterController(IGenericRepository<ClaimHeadMaster, int> claimHeadMasterRepo)
        {
            _IClaimHeadMasterRepository = claimHeadMasterRepo;
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> CreateClaimHeadMaster(ClaimHeadMaster model)
        {
            var response = await _IClaimHeadMasterRepository.CreateEntity(model);
            return Ok(response);
        }

        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
       
        public async Task<IActionResult> GetClaimHeadMaster()
        {
            var response = await _IClaimHeadMasterRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            return Ok(response);
        }

        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> DeleteClaimHeadMaster(int id)
        {
            var deleteModel = await _IClaimHeadMasterRepository.GetAllEntities(x => x.Id == id);
            deleteModel.Entities.ToList().ForEach(data =>
            {
                data.IsActive = false;
                data.IsDeleted = true;
            });

            var response = await _IClaimHeadMasterRepository.DeleteEntity(deleteModel.Entities.FirstOrDefault());
            return Ok(response);
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> UpdateClaimHeadMaster(CompanyMaster model)
        {
            var deleteModels = await _IClaimHeadMasterRepository.GetAllEntities(x => x.Id == model.Id);

            deleteModels.Entities.ToList().ForEach(data => {
                data.IsActive = false;
                data.IsDeleted = true;
            });


            var createResponse = await _IClaimHeadMasterRepository.UpdateEntity(deleteModels.Entities.FirstOrDefault());

            return Ok(createResponse);

        }
    }
}
