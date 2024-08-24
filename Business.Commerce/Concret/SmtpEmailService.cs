using Business.Commerce.Abstract;
using DataAccess.Commerce.Abstract;
using Microsoft.Extensions.Options;
using Shared.Commerce;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class SmtpEmailService : IEmailService
{
    private readonly IEmailDal _emailDal;
    public SmtpEmailService(IEmailDal _emailDal)
    {
        this._emailDal = _emailDal;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
       await _emailDal.SendEmailAsync(toEmail, subject, body);
    }


}
