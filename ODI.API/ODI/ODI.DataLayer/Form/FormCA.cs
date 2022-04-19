using Microsoft.AspNetCore.Http;
using ODI.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODI.DataLayer.Form
{
    [Table("FormCA", Schema = "Form")]
    public class FormCA : BaseModel<int>
    {
        public int UserDetailId { get; set; }
        public int CIRPDetailId { get; set; }
        public string IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
        public string CorrespondenceAddress { get; set; }
        public string EmailId { get; set; }
        public decimal PrincipalClaim { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmountOfInterestClaim { get; set; }
        public decimal OtherAmount { get; set; }
        public string ReferenceDocuments { get; set; }
        public string IncurredDebt { get; set; }
        public string MutualDetails { get; set; }
        public string SecurityHeld { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankAccountType { get; set; }
        public string IFSCCode { get; set; }
        public string MICRCode { get; set; }
        public string DomesticNRIAccount { get; set; }
        public string AdditionalInformation { get; set; }
        public string UploadDulySignedFormCA { get; set; }
        [NotMapped]
        public IFormFile FormFile { get; set; }

    }
}
