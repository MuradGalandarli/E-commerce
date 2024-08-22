using Business.Commerce.Abstract;
using Microsoft.Extensions.Options;
using Shared.Commerce;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class SmtpEmailService : IEmailService
{
    private readonly SmtpSettings _settings;
    private readonly string _smtpServer;
    private readonly int _smtpPort;
    private readonly string _smtpUser;
    private readonly string _smtpPass;

    public SmtpEmailService(IOptions<SmtpSettings> options)
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
