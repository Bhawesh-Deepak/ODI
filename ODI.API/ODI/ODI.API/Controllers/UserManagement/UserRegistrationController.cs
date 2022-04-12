using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODI.API.Helpers;
using ODI.DataLayer.UserManagement;
using ODI.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODI.API.Controllers.UserManagement
{
  
    [Route("api/ODI/[controller]/[action]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IGenericRepository<UserDetails, int> _IUserDetailsRepository;
        private readonly IGenericRepository<Authenticate, int> _IAuthenticateRepository;
        public UserRegistrationController(IGenericRepository<UserDetails, int> userDetailsRepository,
            IGenericRepository<Authenticate, int> authenticateRepository)
        {
            _IUserDetailsRepository = userDetailsRepository;
            _IAuthenticateRepository = authenticateRepository;
        }
       
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> CreateNewUser(UserDetails userDetails)
        {
            try
            {
                var responseUser = await _IUserDetailsRepository.CreateEntity(userDetails);
                var userdetail = await _IUserDetailsRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted && x.UserCode.Trim() == userDetails.UserCode.Trim());
                var model = new Authenticate()
                {
                    UserDetailId = userdetail.Entities.FirstOrDefault().Id,
                    UserName = userDetails.UserCode.Trim(),
                    Password = PasswordEncryptor.Instance.Encrypt(userDetails.Password.Trim(), "ODIPASSWORDKEY"),
                    RoleId = 4,
                    DisplayUserName = userDetails.FirstName,
                    ForgetPasswordTime = DateTime.Now,
                };
                var authenticateresponse = await _IAuthenticateRepository.CreateEntity(model);
                return Ok(authenticateresponse);

            }
            catch (Exception ex)
            {
                return Ok(false);

            }
        }
    }
}
