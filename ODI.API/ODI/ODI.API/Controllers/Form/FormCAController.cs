using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODI.API.Helpers.BlobHelper;
using ODI.API.Model;
using ODI.DataLayer.Form;
using ODI.DataLayer.UserManagement;
using ODI.Repository.GenericRepository;
using ODI.Repository.ReqRespVm.Request.Form;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        public async Task<IActionResult> CreateFormCA([FromForm] FormCAModel formCAViewModel)
        {
            try
            {

                var userResponse = await _IUserDetailsRepository.GetAllEntities(x => x.UserCode.Trim() == formCAViewModel.userId.Trim());
                userResponse.Entities.First().CustomerId = formCAViewModel.customerId;
                userResponse.Entities.First().ProjectDetailId = Convert.ToInt32(formCAViewModel.projectDetails);
                userResponse.Entities.First().TowerNumber = formCAViewModel.towerNumber;
                userResponse.Entities.First().FlatNumber = formCAViewModel.flatNumber;
                userResponse.Entities.First().BookingDate = Convert.ToDateTime(formCAViewModel.bookingDate);
                userResponse.Entities.First().StatusOfUnit = formCAViewModel.statusOfUnit;
                userResponse.Entities.First().TotalCost = formCAViewModel.totalCost;
                userResponse.Entities.First().SuperArea = formCAViewModel.superArea;
                var userUpdateResponse = await _IUserDetailsRepository.UpdateEntity(userResponse.Entities.FirstOrDefault());
                var formca = new FormCA()
                {
                    UserDetailId = userResponse.Entities.FirstOrDefault().Id,
                    CIRPDetailId = 1,
                    IdentificationType = formCAViewModel.identificationType,
                    IdentificationNumber = formCAViewModel.identificationNumber,
                    CorrespondenceAddress = formCAViewModel.crosspondenceAddress,
                    EmailId = formCAViewModel.emailId,
                    PrincipalClaim = Convert.ToDecimal(formCAViewModel.totalPricipleAmountClaim),
                    TaxAmount = Convert.ToDecimal(formCAViewModel.taxAmount),
                    TotalAmountOfInterestClaim = Convert.ToDecimal(formCAViewModel.totalAmountOfInterest),
                    OtherAmount = Convert.ToDecimal(formCAViewModel.otherAmount),
                    ReferenceDocuments = formCAViewModel.documentDetails,
                    IncurredDebt = formCAViewModel.debtIncured,
                    MutualDetails = formCAViewModel.mutualCreditAndDebit,
                    // SecurityHeld=formCAViewModel.emailId,
                    BankAccountName = formCAViewModel.bankAccount,
                    BankAccountType = formCAViewModel.accountType,
                    BankAccountNumber = formCAViewModel.accountNumber,
                    IFSCCode = formCAViewModel.iFSCCode,
                    MICRCode = formCAViewModel.mICRCode,
                    DomesticNRIAccount = formCAViewModel.nRIAccount,
                    //AdditionalInformation=formCAViewModel.accountNumber,
                    UploadDulySignedFormCA = "",
                };
                var formcaResponse = await _IFormCARepository.CreateEntity(formca);
                var formcadetail = await _IFormCARepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
                int formcaId = (from record in formcadetail.Entities orderby record.Id select record.Id).Last();
                var formCaDocment = new List<FormCADocument>();
                for (int i = 0; i < formCAViewModel.file.Count(); i++)
                {
                    formCaDocment.Add(new FormCADocument()
                    {
                        FormCAId = formcaId,
                        DocumentName = formCAViewModel.name[i].ToString().Trim(),
                        DocumentPath = new BlobHelper().UploadImageToFolder(formCAViewModel.file[i], _IHostingEnviroment),
                    });
                }
                var formcaDocumetresponse = await _IFormCADocumentRepository.CreateEntities(formCaDocment.ToArray());
                var formcacalculation = new List<FormCACalculation>();
                foreach (var item in formCAViewModel.PrincipleCalculate)
                {
                    formcacalculation.Add(new FormCACalculation()
                    {
                        FormCAId = formcaId,
                        PrincipalAmount=Convert.ToDecimal(item.Principle),
                        Interest = Convert.ToDecimal(item.InterestPercent),
                        PaymentDate = Convert.ToDateTime(item.PaymentDate),
                        InsolvencyDate = Convert.ToDateTime(item.InsolvencyDate),
                        InterestAmount = Convert.ToDecimal(item.IntrAmount),
                        TotalAmount = Convert.ToDecimal(item.ttlAmnt),
                    });
                }
                var formcaCalculationresponse = await _IFormCACalculationRepository.CreateEntities(formcacalculation.ToArray());
                return Ok(formcaCalculationresponse);
            }
            catch (Exception ex)
            {
                return Ok();

            }
        }
        [HttpGet]
        public async Task<IActionResult> CreatePDF()
        {

            //Create a new PDF document
            PdfDocument doc = new PdfDocument();
            //Add a page
            PdfPage page = doc.Pages.Add();
            //Create a PdfGrid
            PdfGrid pdfGrid = new PdfGrid();
            //Create a DataTable
            DataTable dataTable = new DataTable();
            //Add columns to the DataTable
            dataTable.Columns.Add("ProductID");
            dataTable.Columns.Add("ProductName");
            dataTable.Columns.Add("Quantity");
            dataTable.Columns.Add("UnitPrice");
            dataTable.Columns.Add("Discount");
            dataTable.Columns.Add("Price");
            //Add rows to the DataTable
            dataTable.Rows.Add(new object[] { "CA-1098", "Queso Cabrales", "12", "14", "1", "167" });
            dataTable.Rows.Add(new object[] { "LJ-0192-M", "Singaporean Hokkien Fried Mee", "10", "20", "3", "197" });
            dataTable.Rows.Add(new object[] { "SO-B909-M", "Mozzarella di Giovanni", "15", "65", "10", "956" });
            //Assign data source
            pdfGrid.DataSource = dataTable;
            //Draw grid to the page of PDF document
            pdfGrid.Draw(page, new PointF(10, 10));
            //Save the PDF document to stream
            MemoryStream stream = new MemoryStream();
            doc.Save(stream);
            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;
            //Close the document.
            doc.Close(true);
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");

            fileStreamResult.FileDownloadName = "Sample.pdf";

            return fileStreamResult;
        }
    }
}