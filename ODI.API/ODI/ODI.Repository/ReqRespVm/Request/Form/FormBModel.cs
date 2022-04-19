using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODI.Repository.ReqRespVm.Request.Form
{
    public class FormBModel
    {
        public int creditorId { get; set; }
        public string identificationtype { get; set; }
        public string identificationNumber { get; set; }
        public string crosspondenceAddress { get; set; }
        public string emailId { get; set; }
        public string totalPrincipleClaim { get; set; }
        public string taxAmount { get; set; }
        public string taxAmountInterest { get; set; }
        public string totalAmountInterestClaim { get; set; }
        public string otherAmount { get; set; }
        public string documentDetails { get; set; }
        public string disputeDetails { get; set; }
        public string debtIncured { get; set; }
        public string mutualCredit { get; set; }
        public string retention { get; set; }
        public string securityHeld { get; set; }
        public string bankAccountName { get; set; }
        public string accountNumber { get; set; }
        public string accountType { get; set; }
        public string ifscCode { get; set; }
        public string micrCode { get; set; }
        public string domesticNRIAccount { get; set; }
        public List<string> name { get; set; }
        public IList<IFormFile> file { get; set; }

    }
}
