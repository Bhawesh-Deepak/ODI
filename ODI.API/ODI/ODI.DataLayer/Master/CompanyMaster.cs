using ODI.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODI.DataLayer.Master
{
    [Table("CompanyMaster", Schema = "Master")]
    public class CompanyMaster:BaseModel<int>
    {
        public string Name { get; set; }
    }
}
