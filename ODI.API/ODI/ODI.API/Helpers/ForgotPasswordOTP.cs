using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using ODI.DataLayer.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ODI.API.Helpers
{
    public class ForgotPasswordOTP
    {
        public async Task<bool> SendOtp(UserDetails userDetails, string message)
        {
            var isMailSend = false;
            try
            {
                var messages = new MimeMessage();
                messages.From.Add(new MailboxAddress("ODIOTP", "squarehr@kudotech.in"));
                messages.To.Add(new MailboxAddress("ODIOTP", userDetails.EmailId));
                messages.Subject = "Orior Developers & Infrastructure";
                messages.Body = new TextPart(TextFormat.Html)
                {
                    Text = message
                };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {

                    client.Connect("smtp.gmail.com", 587, false);

                    //SMTP server authentication if needed
                    client.Authenticate("squarehr@kudotech.in", "Kudotech@1234");

                    client.Send(messages);

                    client.Disconnect(true);
                    isMailSend = true;
                }
                return isMailSend;

            }
            catch (Exception ex)
            {
                isMailSend = false;
                //Console.WriteLine(ex.Message);
                //return StatusCode(500, "Error occured");
                return isMailSend;

            }

            //return (true);
        }

        public string GetRandomOtp()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var stringChars = new char[5];

            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }

        public string GetOtpMessage(UserDetails userDetails, string randomPassword) =>
            $"<p>Dear  {userDetails?.FirstName + " " + userDetails?.LastName} </p><br /> " +
            $"<p>You requested to reset the password for your Orior Developers & Infrastructure account with the User ID:  {userDetails?.UserCode} <br /><br />" +
            $"<p>Please use the mail OTP to reset your Password.</p> " +
            $"<p>{randomPassword }</p> " +
            $"<p>Your Sincerly,</ p><br /> " +
            $"<p>Orior Developers & Infrastructure Team</ p><br /> " +
            $"<p>Note: This notification is system generated. Do not reply to this auto-generated notification.</p>" ;


        //$"<p>Dear {userDetails?.FirstName}.  Your OTP is {randomPassword}" + "</p>"+
        //   $" Do not share with any one for security. Orior Developers & Infrastructure.";
    }
}
