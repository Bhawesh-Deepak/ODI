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
                     
                };
                var authenticateresponse = await _IAuthenticateRepository.CreateEntity(model);
                return Ok(authenticateresponse);

            }
            catch (Exception ex)
            {
                return Ok(false);

            }
        }
        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetUserDetailById(int Id)
        {
            try
            {
                 
                var userdetail = await _IUserDetailsRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted && x.Id == Id);
                
                return Ok(userdetail);

            }
            catch (Exception ex)
            {
                string template = $"Controller name {nameof(UserRegistrationController)} action name {nameof(GetUserDetailById)} exception is {ex.Message}";
                 
                return Ok(false);

            }
        }
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> UpdateUserProfile(UserDetails userDetails)
        {
            try
            {

                var userdetail = await _IUserDetailsRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted && x.Id == userDetails.Id);
                userdetail.Entities.FirstOrDefault().FirstName = userDetails.FirstName;
                userdetail.Entities.FirstOrDefault().LastName = userDetails.LastName;
                userdetail.Entities.FirstOrDefault().EmailId = userDetails.EmailId;
                userdetail.Entities.FirstOrDefault().MobileNumber = userDetails.MobileNumber;
                userdetail.Entities.FirstOrDefault().isCarporateDebtor = userDetails.isCarporateDebtor;
                var updateResponse= await _IUserDetailsRepository.UpdateEntity(userdetail.Entities.FirstOrDefault());
                return Ok(updateResponse);

            }
            catch (Exception ex)
            {
                string template = $"Controller name {nameof(UserRegistrationController)} action name {nameof(GetUserDetailById)} exception is {ex.Message}";

                return Ok(Response.StatusCode);

            }
        }
    }
}
