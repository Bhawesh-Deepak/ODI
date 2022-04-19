using ODI.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODI.DataLayer.Form
{
    [Table("FormB", Schema = "Form")]
    public class FormB : BaseModel<int>
    {
        public int UserDetailId { get; set; }
        public string IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
        public string CorrespondenceAddress { get; set; }
        public string ClaimAmount { get; set; }
        public string TaxAmount { get; set; }
        public string ClaimInterestAmount { get; set; }
        public string OtherAmount { get; set; }
        public string DocumentsDetails { get; set; }
        public string DisputesDetails { get; set; }
        public string IncurredDetails { get; set; }
        public string MutualCredit { get; set; }
        public string RetentionDetails { get; set; }
        public string SecurityDetails { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankAccountType { get; set; }
        public string IFSCCode { get; set; }
        public string MICRCode { get; set; }
        public string DomesticNRIAccount { get; set; }
        public string DulySignedFormBPath { get; set; }
        public string FormPdfUrl { get; set; }
        
    }
}
