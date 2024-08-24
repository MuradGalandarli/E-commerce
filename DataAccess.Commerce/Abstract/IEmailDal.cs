using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.Abstract
{
    public interface IEmailDal
    {
        public  Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
