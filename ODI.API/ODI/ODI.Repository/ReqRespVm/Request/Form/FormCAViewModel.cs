using ODI.DataLayer.Form;
using ODI.DataLayer.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODI.Repository.ReqRespVm.Request.Form
{
    public class FormCAViewModel
    {
        public UserDetails UserDetail { get; set; }
        public FormCA formCA { get; set; }
        public List<FormCADocument> FormCADocuments { get; set; }
        public List<FormCACalculation> FormCACalculations { get; set; }
        
    }
}
