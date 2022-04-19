using ODI.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODI.DataLayer.Form
{
    [Table("FormBDocument", Schema = "Form")]
    public class FormBDocument:BaseModel<int>
    {
        public int FormBId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
    }
}
