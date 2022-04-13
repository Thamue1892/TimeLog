namespace ServiceFramework.Interface
{
    public interface IEmail
    {
        void SendEmail(string sender, string recipient, string mailServer, string subject, string body);
    }
}