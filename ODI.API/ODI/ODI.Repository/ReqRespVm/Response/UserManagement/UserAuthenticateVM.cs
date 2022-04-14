using ODI.DataLayer.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODI.Repository.ReqRespVm.Response.UserManagement
{
    public class UserAuthenticateVM
    {
        public UserDetails userDetails { get; set; }
        public bool IsSucess { get; set; }
        public string Message { get; set; }
    }
}
