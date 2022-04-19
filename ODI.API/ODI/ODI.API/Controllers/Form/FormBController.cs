using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODI.API.Helpers.BlobHelper;
using ODI.DataLayer.Form;
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
    public class FormBController : ControllerBase
    {
        private readonly IGenericRepository<FormB, int> _IFormBRepository;
        private readonly IHostingEnvironment _IHostingEnviroment;

        public FormBController(IGenericRepository<FormB, int> formBRepo, IHostingEnvironment hostingEnvironment)
        {
            _IFormBRepository = formBRepo;
            _IHostingEnviroment = hostingEnvironment;
        }
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> CreateFormB([FromForm] FormBModel formBModel)
        {
            var formB = new FormB()
            {
                UserDetailId = formBModel.creditorId,
                IdentificationType = formBModel.identificationtype,
                IdentificationNumber = formBModel.identificationNumber,
                CorrespondenceAddress = formBModel.crosspondenceAddress,
                ClaimAmount = formBModel.totalPrincipleClaim,
                TaxAmount = formBModel.taxAmount,
                ClaimInterestAmount = formBModel.totalAmountInterestClaim,
                OtherAmount = formBModel.otherAmount,
                DocumentsDetails = formBModel.documentDetails,
                DisputesDetails = formBModel.disputeDetails,
                IncurredDetails = formBModel.debtIncured,
                MutualCredit = formBModel.mutualCredit,
                RetentionDetails = formBModel.retention,
                SecurityDetails = formBModel.securityHeld,
                BankAccountName = formBModel.bankAccountName,
                BankAccountNumber = formBModel.accountNumber,
                BankAccountType = formBModel.accountType,
                IFSCCode = formBModel.ifscCode,
                MICRCode = formBModel.micrCode,
                DomesticNRIAccount = formBModel.domesticNRIAccount,
                //  DulySignedFormBPath=formBModel.si
            };
            var response = await _IFormBRepository.CreateEntity(formB);
            var formBDocument = new List<FormBDocument>();

            foreach (var formFile in formBModel.file)
            {
                formBDocument.Add(new FormBDocument()
                {
                    FormBId = 1,
                    DocumentName = "",
                   // DocumentPath = new BlobHelper().UploadImageToFolder((IFormFile)formFile, _IHostingEnviroment),
                });
            }
                //for (int i = 0; i < formBModel.file.Count(); i++)
                //{
                //    formBDocument.Add(new FormBDocument()
                //    {
                //        FormBId = 1,
                //        DocumentName = "",
                //        DocumentPath = "",//new BlobHelper().UploadImageToFolder( formBModel.file[i], _IHostingEnviroment),
                //    }) ;
                //}
                return Ok(response);
        }

    }
}
