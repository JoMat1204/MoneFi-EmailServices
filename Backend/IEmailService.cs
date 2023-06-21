using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Sabio.Models.AppSettings;
using Sabio.Models.Requests;
using sib_api_v3_sdk.Model;

namespace Sabio.Services
{
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
}