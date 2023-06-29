public interface IEmailService
{
    void SendTestEmail(SendEmailRequest request);
    void SendAdminMessage(SendEmailRequest request);
    void ContactUs(SendEmailRequest request);
    void NewUserEmail(SendEmailRequest request, string confirmUrl);
    void SendChangePasswordEmail(SendEmailRequest request, string token);
    void UpdateUserPassword(SendEmailRequest request, string requestUrl);
    void UpdateUserEmail(SendEmailRequest request, string requestUrl);
}
