namespace Utility.Service.Infrastructure
{
    public interface ISendMailService
    {
        Task SendMail(string toMail, string subject, string body);
    }
}
