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
    public class CIRPDetailController : ControllerBase
    {
        private readonly IGenericRepository<CIRPDetail, int> _ICIRPDetailRepository;
        public CIRPDetailController(IGenericRepository<CIRPDetail, int> cIRPDetailRepo)
        {
            _ICIRPDetailRepository = cIRPDetailRepo;
        }
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> CreateCIRPDetail(CIRPDetail model)
        {
            var response = await _ICIRPDetailRepository.CreateEntity(model);
            return Ok(response);
        }

        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetCIRPDetail()
        {
            var response = await _ICIRPDetailRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            return Ok(response);
        }

        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> DeleteCIRPDetail(int id)
        {
            var deleteModel = await _ICIRPDetailRepository.GetAllEntities(x => x.Id == id);
            deleteModel.Entities.ToList().ForEach(data =>
            {
                data.IsActive = false;
                data.IsDeleted = true;
            });

            var response = await _ICIRPDetailRepository.DeleteEntity(deleteModel.Entities.FirstOrDefault());
            return Ok(response);
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> UpdateCIRPDetail(CIRPDetail model)
        {
            var createResponse = await _ICIRPDetailRepository.UpdateEntity(model);

            return Ok(createResponse);

        }
    }
}
