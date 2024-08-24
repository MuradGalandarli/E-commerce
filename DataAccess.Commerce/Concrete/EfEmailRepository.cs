using DataAccess.Commerce.Abstract;
using Microsoft.Extensions.Options;
using Shared.Commerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.Concrete
{
    public class EfEmailRepository : IEmailDal
    {

        private readonly SmtpSettings _settings;
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUser;
        private readonly string _smtpPass;

        public EfEmailRepository(IOptions<SmtpSettings> options)
        {
            _settings = options.Value;
            _smtpServer = _settings.Host;
            _smtpPort = _settings.Port;
            _smtpUser = _settings.UserName;
            _smtpPass = _settings.Password;
        }


        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(_smtpUser, _smtpPass);
                smtpClient.EnableSsl = true; // SSL bağlantısını etkinleştirin

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpUser),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(toEmail);

                await smtpClient.SendMailAsync(mailMessage);
            }

        }
    }
}
