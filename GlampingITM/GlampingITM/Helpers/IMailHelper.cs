using GlampingITM.Common;

namespace GlampingITM.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string toName, string toEmail, string subject, string body);
    }

}
