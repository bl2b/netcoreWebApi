namespace XYC.Domain.Abstract.Sample
{
    public interface IMailService
    {
        void Send(string subject, string message);
    }
}