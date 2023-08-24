using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using Utility.Service.Infrastructure;

namespace Utility.Service.Implementation
{
    public class SendMailService : ISendMailService
    {

        private readonly IConfiguration _configuration;

        public SendMailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendMail(string toMail, string subject, string body)
        {
            string fromEmail = _configuration["EmailSetting:From"];
            string fromPassword = _configuration["EmailSetting:Password"];
            string SmtpServer = _configuration["EmailSetting:SmtpServer"];
            int Port = int.Parse(_configuration["EmailSetting:Port"]);
            try
            {

                using (var smtpClient = new SmtpClient(SmtpServer, Port))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Credentials = new NetworkCredential(fromEmail, fromPassword);
                    smtpClient.ServicePoint.MaxIdleTime = 1;
                    using (var mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(fromEmail);
                        mailMessage.To.Add(toMail);
                        mailMessage.Subject = subject;
                        mailMessage.IsBodyHtml = true;
                        mailMessage.Body = body;
                        try
                        {
                            smtpClient.Send(mailMessage);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }

            }
            catch (Exception e)
            {
            }
            return Task.CompletedTask;
        }
    }
}
