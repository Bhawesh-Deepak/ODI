using ODI.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODI.DataLayer.UserManagement
{
    [Table("Authenticate", Schema = "UserManagement")]
    public class Authenticate : BaseModel<int>
    {public int Id { get; set; }
        public int UserDetailId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string DisplayUserName { get; set; }
        public bool IsPasswordExpired { get; set; }
        public bool IsLocked { get; set; }
        public string ForgetPasswordCode { get; set; }
        public DateTime ? ForgetPasswordTime { get; set; }
     
    }
}
