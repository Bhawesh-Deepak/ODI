using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODI.API.Helpers;
using ODI.DataLayer.UserManagement;
using ODI.Repository.GenericRepository;
using ODI.Repository.ReqRespVm.Request;
using ODI.Repository.ReqRespVm.Request.UserManagement;
using ODI.Repository.ReqRespVm.Response.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODI.API.Controllers.UserManagement
{
    [Route("api/ODI/[controller]/[action]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IGenericRepository<UserDetails, int> _IUserDetailsRepository;
        private readonly IGenericRepository<Authenticate, int> _IAuthenticateRepository;
        public AuthenticateController(IGenericRepository<UserDetails, int> userDetailsRepository,
            IGenericRepository<Authenticate, int> authenticateRepository)
        {
            _IUserDetailsRepository = userDetailsRepository;
            _IAuthenticateRepository = authenticateRepository;
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> Authenticate(AuthenticateVM model)
        {
            try
            {
                model.Password = PasswordEncryptor.Instance.Encrypt(model.Password, "ODIPASSWORDKEY");
                var response = await _IAuthenticateRepository.GetAllEntities(x => x.UserName.ToLower().Trim() == model.UserName.Trim().ToLower()
                && x.Password.Trim().ToLower() == model.Password.Trim().ToLower());

                if (response.Entities.Any())
                {
                    var userDetail = await _IUserDetailsRepository.GetAllEntities(x => x.Id == response.Entities.First().UserDetailId);
                    var responseDeatils = new UserAuthenticateVM()
                    {
                        userDetails = userDetail.Entities.FirstOrDefault(),
                        IsSucess = true,
                        Message = "Sucess"
                    };

                    return await Task.Run(() => Ok(responseDeatils));


                }
                else
                {
                    var responseDeatils = new UserAuthenticateVM()
                    {

                        IsSucess = false,
                        Message = "Invalid Login Credential!!!!"
                    };
                    return await Task.Run(() => Ok(responseDeatils));


                }

            }
            catch (Exception ex)
            {
                string template = $"Controller name {nameof(AuthenticateController)} action name {nameof(Authenticate)} exception is {ex.Message}";

                return Ok();
            }

        }
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {
            try
            {
                model.OldPassword = PasswordEncryptor.Instance.Encrypt(model.OldPassword, "ODIPASSWORDKEY");
                model.NewPassword = PasswordEncryptor.Instance.Encrypt(model.NewPassword, "ODIPASSWORDKEY");
                var response = await _IAuthenticateRepository.GetAllEntities(x => x.UserName.ToLower().Trim() == model.UserName.Trim().ToLower()
                && x.Password.Trim().ToLower() == model.OldPassword.Trim().ToLower());
                if (response.Entities.Any())
                {
                    response.Entities.FirstOrDefault().Password = model.NewPassword;
                    var updateresponse = await _IAuthenticateRepository.UpdateEntity(response.Entities.FirstOrDefault());
                    return await Task.Run(() => Ok(updateresponse));
                }
                else
                {
                    return await Task.Run(() => Ok(false));
                }
            }
            catch (Exception ex)
            {
                string template = $"Controller name {nameof(AuthenticateController)} action name {nameof(Authenticate)} exception is {ex.Message}";
                return Ok();
            }

        }
        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> ForgetPassword(string UserName)
        {
            try
            {
                var empDetails = await _IUserDetailsRepository.GetAllEntities(x => x.UserCode.Trim().ToLower() == UserName.Trim().ToLower());

                var randomOtp = new ForgotPasswordOTP().GetRandomOtp();

                if (empDetails != null && empDetails.Entities.Any())
                {
                    var authDetails = await _IAuthenticateRepository.GetAllEntities(x => x.UserName.Trim().ToLower() == UserName.Trim().ToLower());

                    if (authDetails != null && authDetails.Entities.Any())
                    {
                        var updateModel = authDetails.Entities.First();
                        updateModel.ForgetPasswordCode = randomOtp;
                        updateModel.ForgetPasswordTime = DateTime.Now;
                        updateModel.UpdatedBy = 1;
                        updateModel.UpdatedDate = DateTime.Now;
                        var updateResponse = await _IAuthenticateRepository.UpdateEntity(updateModel);
                        if (updateResponse.Message == "success")
                        {
                            var message = new ForgotPasswordOTP().GetOtpMessage(empDetails.Entities.First(), randomOtp);
                            var sentOtpStatus = new ForgotPasswordOTP().SendOtp(empDetails.Entities.First(), message);
                            return StatusCode(200, "Success");
                        }
                        else
                        {
                            return StatusCode(500, "Error");
                        }
                    }
                    else
                    {
                        return StatusCode(500, "Error");
                    }
                }
                else { 
                    return StatusCode(402, "Invalid UserId"); }

            }
            catch (Exception ex)
            {
                string template = $"Controller name {nameof(AuthenticateController)} action name {nameof(ForgetPassword)} exception is {ex.Message}";

                return StatusCode(500, "Error");
            }
        }
        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> ForgetPasswordPost(string otpCode, string UserName, string NewPassword)
        {
            try
            {
                var empDetails = await _IUserDetailsRepository.GetAllEntities(x => x.UserCode.Trim().ToLower() == UserName.Trim().ToLower());
                var response = await _IAuthenticateRepository.GetAllEntities(x => x.UserDetailId == empDetails.Entities.First().Id && x.ForgetPasswordCode.Trim().ToLower() == otpCode.Trim().ToLower());
                if (response.Entities.Any())
                {
                    var start = DateTime.Now;


                    if ((start - Convert.ToDateTime(response.Entities.FirstOrDefault().ForgetPasswordTime)).TotalMinutes >= 15)
                    {
                        return StatusCode(300, "OTP Expire");
                    }
                    else
                    {
                        var newPassword = PasswordEncryptor.Instance.Encrypt(NewPassword, "ODIPASSWORDKEY");
                        var authModel = await _IAuthenticateRepository.GetAllEntities(x => x.UserDetailId == empDetails.Entities.First().Id);
                        authModel.Entities.First().Password = newPassword;
                        authModel.Entities.First().ForgetPasswordCode = null;
                        authModel.Entities.First().ForgetPasswordTime = null;
                        authModel.Entities.First().UpdatedBy = empDetails.Entities.First().Id;
                        authModel.Entities.First().UpdatedDate = DateTime.Now;
                        var updateResponse = await _IAuthenticateRepository.UpdateMultipleEntity(authModel.Entities.ToArray());
                    }
                }

              return StatusCode(200, "Success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }
    }
}
