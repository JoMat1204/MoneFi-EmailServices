using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Sabio.Models.AppSettings;
using Sabio.Models.Domain;
using Sabio.Models.Requests;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;


namespace Sabio.Services
{
    public class EmailService : IEmailService 
    {
        private AppKeys _appkey;
        IWebHostEnvironment _environment;

        public EmailService(IOptions<AppKeys> appkeys , IWebHostEnvironment webHostEnvironment)
        {
            _appkey = appkeys.Value;
            Configuration.Default.AddApiKey("api-key", _appkey.SendInBlueAppKey);
            _environment = webHostEnvironment;
        }

        #region ContactUs
        public void ContactUs(SendEmailRequest request)
        {
            string templatePath = _environment.WebRootPath + "/EmailTemplates/Template.html";
            string readText = File.ReadAllText(templatePath);

            var apiInstance = new TransactionalEmailsApi();

            List<SendSmtpEmailTo> sendSmtpEmailTo = new List<SendSmtpEmailTo>();
            SendSmtpEmailTo sendSmtpEmailTo1 = new SendSmtpEmailTo(request.To.Email, request.To.Name);
            sendSmtpEmailTo.Add(sendSmtpEmailTo1);



            var sendSmtpEmail = new SendSmtpEmail(sender: new SendSmtpEmailSender(email: request.To.Email), to: sendSmtpEmailTo, subject: request.Subject, htmlContent: readText);
            SendInBlue(sendSmtpEmail);
        } 
        #endregion


        #region SendInBlue - Private
        private async void SendInBlue(SendSmtpEmail email)
        {
            TransactionalEmailsApi transactionalEmailsApi = new TransactionalEmailsApi();
            await transactionalEmailsApi.SendTransacEmailAsync(email);
        }
        #endregion

           
        #region Admin Message
        public void SendAdminMessage(SendEmailRequest request)
        {

            string templatePath = _environment.WebRootPath + "/EmailTemplates/Template.html";
            string readText = File.ReadAllText(templatePath);

            var apiInstance = new TransactionalEmailsApi();


            List<SendSmtpEmailTo> sendSmtpEmailTo = new List<SendSmtpEmailTo>();
            SendSmtpEmailTo sendSmtpEmailTo1 = new SendSmtpEmailTo(request.To.Email, request.To.Name);
            sendSmtpEmailTo.Add(sendSmtpEmailTo1);



            var sendSmtpEmail = new SendSmtpEmail(sender: new SendSmtpEmailSender(email: request.To.Email), to: sendSmtpEmailTo, subject: request.Subject, htmlContent: readText);

            SendInBlue(sendSmtpEmail);
        } 
        #endregion


        #region SendEmail
        public void SendTestEmail(SendEmailRequest request)
        {
         
            string templatePath = _environment.WebRootPath + "/EmailTemplates/Template.html"; 
            string readText = File.ReadAllText(templatePath);     


            var apiInstance = new TransactionalEmailsApi();

            List<SendSmtpEmailTo> sendSmtpEmailTo = new List<SendSmtpEmailTo>();
            SendSmtpEmailTo sendSmtpEmailTo1 = new SendSmtpEmailTo(request.To.Email , request.To.Name);
            sendSmtpEmailTo.Add(sendSmtpEmailTo1);



            var sendSmtpEmail = new SendSmtpEmail(sender: new SendSmtpEmailSender(email: request.To.Email), to: sendSmtpEmailTo, subject: request.Subject, htmlContent: readText);

            SendInBlue(sendSmtpEmail);
                                                                      
        }

        public void SendChangePasswordEmail(SendEmailRequest request, string newUrl)
        {

            string templatePath = _environment.WebRootPath + "/EmailTemplates/PasswordResetTemplate.html";
            string readText = File.ReadAllText(templatePath);

            readText = readText.Replace("{{link}}", newUrl);


            var apiInstance = new TransactionalEmailsApi();

            List<SendSmtpEmailTo> sendSmtpEmailTo = new List<SendSmtpEmailTo>();
            SendSmtpEmailTo sendSmtpEmailTo1 = new SendSmtpEmailTo(request.To.Email, request.To.Name);
            sendSmtpEmailTo.Add(sendSmtpEmailTo1);



            var sendSmtpEmail = new SendSmtpEmail(sender: new SendSmtpEmailSender(email: request.To.Email), to: sendSmtpEmailTo, subject: request.Subject, htmlContent: readText);

            SendInBlue(sendSmtpEmail);

        }
        #endregion

        #region NewUserEmail
        public void NewUserEmail(SendEmailRequest request, string confirmUrl)
        {
            string templatePath = _environment.WebRootPath + "/EmailTemplates/NewUserEmailTemplate.html";
            string readText = File.ReadAllText(templatePath);

            readText = readText.Replace("{{link}}", confirmUrl);

            var apiInstance = new TransactionalEmailsApi();

            List<SendSmtpEmailTo> sendSmtpEmailTo = new List<SendSmtpEmailTo>();
            SendSmtpEmailTo sendSmtpEmailTo1 = new SendSmtpEmailTo(request.To.Email, request.To.Name);
            sendSmtpEmailTo.Add(sendSmtpEmailTo1);

            var sendSmtpEmail = new SendSmtpEmail(sender: new SendSmtpEmailSender(email: request.To.Email), to: sendSmtpEmailTo, subject: request.Subject, htmlContent: readText);
            SendInBlue(sendSmtpEmail);
        }
        #endregion

        #region UpdateUserSettings
        public void UpdateUserPassword(SendEmailRequest request, string requestUrl)
        {
            string templatePath = _environment.WebRootPath + "/EmailTemplates/PasswordUpdateTemplate.html";
            string readText = File.ReadAllText(templatePath);

            readText = readText.Replace("{{link}}", requestUrl);

            var apiInstance = new TransactionalEmailsApi();

            List<SendSmtpEmailTo> sendSmtpEmailTo = new List<SendSmtpEmailTo>();
            SendSmtpEmailTo sendSmtpEmailTo1 = new SendSmtpEmailTo(request.To.Email, request.To.Name);
            sendSmtpEmailTo.Add(sendSmtpEmailTo1);

            var sendSmtpEmail = new SendSmtpEmail(sender: new SendSmtpEmailSender(email: request.To.Email), to: sendSmtpEmailTo, subject: request.Subject, htmlContent: readText);
            SendInBlue(sendSmtpEmail);
        }

        public void UpdateUserEmail(SendEmailRequest request, string requestUrl)
        {
            string templatePath = _environment.WebRootPath + "/EmailTemplates/EmailUpdateTemplate.html";
            string readText = File.ReadAllText(templatePath);

            readText = readText.Replace("{{link}}", requestUrl);

            var apiInstance = new TransactionalEmailsApi();

            List<SendSmtpEmailTo> sendSmtpEmailTo = new List<SendSmtpEmailTo>();
            SendSmtpEmailTo sendSmtpEmailTo1 = new SendSmtpEmailTo(request.To.Email, request.To.Name);
            sendSmtpEmailTo.Add(sendSmtpEmailTo1);

            var sendSmtpEmail = new SendSmtpEmail(sender: new SendSmtpEmailSender(email: request.To.Email), to: sendSmtpEmailTo, subject: request.Subject, htmlContent: readText);
            SendInBlue(sendSmtpEmail);
        }
        #endregion
    }
}   