using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODI.API.Model
{
    public class FormCAModel
    {
        public string userId { get; set; }
        public string accountNumber { get; set; }
        public string accountType { get; set; }
        public string bankAccount { get; set; }
        public string bookingDate { get; set; }
        public string companyName { get; set; }
        public string crosspondenceAddress { get; set; }
        public string customerId { get; set; }
        public string debtIncured { get; set; }
        public string documentDetails { get; set; }
        public string emailId { get; set; }
        public string flatNumber { get; set; }
        public string iFSCCode { get; set; }
        public string identificationNumber { get; set; }
        public string identificationType { get; set; }
        public string insolvencyProfessional { get; set; }
        public string mICRCode { get; set; }
        public string mutualCreditAndDebit { get; set; }


        public string nRIAccount { get; set; }
        public string nameOfFinancialCreditor { get; set; }
        public string otherAmount { get; set; }
        public string principleCalculate { get; set; }
        public string projectDetails { get; set; }
        public string statusOfUnit { get; set; }
        public string superArea { get; set; }
        public string taxAmount { get; set; }
        public string totalAmountOfInterest { get; set; }

        public string totalCost { get; set; }
        public string totalPricipleAmountClaim { get; set; }
        public string towerNumber { get; set; }

        public List<string> name { get; set; }
        public IList<IFormFile> file { get; set; }
        public List<PrincipleCalcullate> PrincipleCalculate { get; set; }
    }

    public class PrincipleCalcullate
    {
        public string InterestPercent { get; set; }
        public string PaymentDate { get; set; }
        public string Principle { get; set; }
        public DateTime InsolvencyDate { get; set; } = DateTime.Parse("2022-02-28");
        public string ttlAmnt { get; set; }
        public string IntrAmount { get; set; }
    }
}