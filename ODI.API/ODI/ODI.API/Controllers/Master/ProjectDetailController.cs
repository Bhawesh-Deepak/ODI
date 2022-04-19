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
    public class ProjectDetailController : ControllerBase
    {
        private readonly IGenericRepository<ProjectDetail, int> _IProjectDetailRepository;
        public ProjectDetailController(IGenericRepository<ProjectDetail, int> projectDetailRepo)
        {
            _IProjectDetailRepository = projectDetailRepo;
        }
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> CreateProjectDetail(ProjectDetail model)
        {
            var response = await _IProjectDetailRepository.CreateEntity(model);
            return Ok(response);
        }

        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetProjectDetail()
        {
            var response = await _IProjectDetailRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            return Ok(response);
        }

        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> DeleteProjectDetail(int id)
        {
            var deleteModel = await _IProjectDetailRepository.GetAllEntities(x => x.Id == id);
            deleteModel.Entities.ToList().ForEach(data =>
            {
                data.IsActive = false;
                data.IsDeleted = true;
            });

            var response = await _IProjectDetailRepository.DeleteEntity(deleteModel.Entities.FirstOrDefault());
            return Ok(response);
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> UpdateProjectDetail(ProjectDetail model)
        {
            var createResponse = await _IProjectDetailRepository.UpdateEntity(model);

            return Ok(createResponse);

        }
    }
}
