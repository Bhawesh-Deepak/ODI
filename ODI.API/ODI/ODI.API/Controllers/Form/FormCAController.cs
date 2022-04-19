using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODI.API.Helpers.BlobHelper;
using ODI.DataLayer.Form;
using ODI.DataLayer.UserManagement;
using ODI.Repository.GenericRepository;
using ODI.Repository.ReqRespVm.Request.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODI.API.Controllers.Form
{
    [Route("api/ODI/[controller]/[action]")]
    [ApiController]
    public class FormCAController : ControllerBase
    {
        private readonly IGenericRepository<UserDetails, int> _IUserDetailsRepository;
        private readonly IGenericRepository<FormCA, int> _IFormCARepository;
        private readonly IGenericRepository<FormCADocument, int> _IFormCADocumentRepository;
        private readonly IGenericRepository<FormCACalculation, int> _IFormCACalculationRepository;
        private readonly IHostingEnvironment _IHostingEnviroment;
        public FormCAController(IGenericRepository<UserDetails, int> userDetailsRepository,
            IGenericRepository<FormCA, int> formCARepository,
             IGenericRepository<FormCADocument, int> formCADocumentRepository,
             IGenericRepository<FormCACalculation, int> formCACalculationRepository,
            IHostingEnvironment hostingEnvironment)
        {
            _IUserDetailsRepository = userDetailsRepository;
            _IFormCARepository = formCARepository;
            _IFormCARepository = formCARepository;
            _IFormCADocumentRepository = formCADocumentRepository;
            _IFormCACalculationRepository = formCACalculationRepository;
            _IHostingEnviroment = hostingEnvironment;

        }
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> CreateFormCA([FromForm] FormCAViewModel formCAViewModel)
        {
            try
            {
                var userResponse = await _IUserDetailsRepository.GetAllEntities(x => x.Id == formCAViewModel.UserDetail.Id);
                userResponse.Entities.First().CustomerId = formCAViewModel.UserDetail.CustomerId;
                userResponse.Entities.First().ProjectDetailId = formCAViewModel.UserDetail.ProjectDetailId;
                userResponse.Entities.First().TowerNumber = formCAViewModel.UserDetail.TowerNumber;
                userResponse.Entities.First().FlatNumber = formCAViewModel.UserDetail.FlatNumber;
                userResponse.Entities.First().BookingDate = formCAViewModel.UserDetail.BookingDate;
                userResponse.Entities.First().StatusOfUnit = formCAViewModel.UserDetail.StatusOfUnit;
                userResponse.Entities.First().TotalCost = formCAViewModel.UserDetail.TotalCost;
                userResponse.Entities.First().SuperArea = formCAViewModel.UserDetail.SuperArea;
                var userUpdateResponse = _IUserDetailsRepository.UpdateEntity(userResponse.Entities.FirstOrDefault());
                var formcaResponse = await _IFormCARepository.CreateEntity(formCAViewModel.formCA);
                var formcadetail = await _IFormCARepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
                int formcaId = (from record in formcadetail.Entities orderby record.Id select record.Id).Last();
                formCAViewModel.FormCADocuments.ForEach(data =>
                {
                    data.FormCAId = formcaId;
                    data.DocumentPath=new BlobHelper().UploadImageToFolder(data.FormFile, _IHostingEnviroment);
                });
                var formcaDocumetresponse = await _IFormCADocumentRepository.CreateEntities(formCAViewModel.FormCADocuments.ToArray());
                formCAViewModel.FormCACalculations.ForEach(data =>{data.FormCAId = formcaId;});
                var formcaCalculationresponse = await _IFormCACalculationRepository.CreateEntities(formCAViewModel.FormCACalculations.ToArray());


                return Ok(formcaCalculationresponse);

            }
            catch (Exception ex)
            {
                return Ok(false);

            }
        }
    }
}
