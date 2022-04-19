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
    [Table("FormCACalculation", Schema = "Form")]
    public class FormCACalculation : BaseModel<int>
    {
        public int FormCAId { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal Interest { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime InsolvencyDate { get; set; }
        public decimal InterestAmount { get; set; }
        public decimal TotalAmount { get; set; }
        [NotMapped]
        public IFormFile FormFile { get; set; }
    }
}
