/*using Business.Commerce.Abstract;
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

    public SmtpEmailService(IOptions<SmtpSettings>opsions)
       
    {
        _settings = _settings = opsions.Value;
        _smtpServer = _settings.Host;
        _smtpPort = _settings.Port;
        _smtpUser = _settings.UserName;
        _smtpPass = _settings.Password;
    }



   *//* private readonly string _smtpServer;
    private readonly int _smtpPort;
    private readonly string _smtpUser;
    private readonly string _smtpPass;

    public SmtpEmailService(
        string smtpServer, int smtpPort, string smtpUser, string smtpPass)
    {

        _smtpServer = smtpServer;
        _smtpPort = smtpPort;
        _smtpUser = smtpUser;
        _smtpPass = smtpPass;

    }
*//*

    public void Sendd()
    {
       var a = "Salam";
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var smtpClient = new SmtpClient(_smtpServer)
        {
            Port = _smtpPort,
            Credentials = new NetworkCredential(_smtpUser, _smtpPass),
            EnableSsl = true,
        };

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
*/


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
