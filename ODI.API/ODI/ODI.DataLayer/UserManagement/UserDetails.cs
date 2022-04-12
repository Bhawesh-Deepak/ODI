using ODI.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODI.DataLayer.UserManagement
{
    [Table("UserDetails", Schema = "UserManagement")]
    public class UserDetails : BaseModel<int>
    {
        public int CompanyId { get; set; }
        public int ClaimHeadId { get; set; }
        public string UserCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public bool isCarporateDebtor { get; set; }
        public bool IsAcceptTermCondition { get; set; }
        [NotMapped]
        public string Password { get; set; }
    }
}
