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
    [Table("FormCADocument", Schema = "Form")]
    public class FormCADocument:BaseModel<int>
    {
        public int FormCAId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
        [NotMapped]
        public IFormFile FormFile { get; set; }
    }
}
