using System;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Mvc;
using Sabio.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sabio.Services.Interfaces;
using Sabio.Services;
using Sabio.Web.Controllers;
using Sabio.Web.Models.Responses;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using NuGet.Configuration;
using System.Security.Policy;
using System.Threading.Tasks;
using Sabio.Models.Requests;

namespace Sabio.Web.Api.Controllers
{
    [Route("api/emails")]
    [ApiController]
    public class EmailAPIController : ControllerBase
    {
        IEmailService _service = null;

        public EmailAPIController(IEmailService service)
        {
            _service = service;
        }
  
        [HttpPost("test")] 
        public ActionResult TestEmailEndpoint(SendEmailRequest emailService)
        {
            int code = 200;
            BaseResponse response = null;
            try
            {
                _service.SendTestEmail(emailService);
                _service.SendAdminMessage(emailService);
                code = 200;
                response = new SuccessResponse();
            }
            catch (Exception e)
            {
                Debug.Print("Error sending test email: " + e.Message);
                code = 500;
                response = new ErrorResponse("Error sending test email: " + e.Message);
            }
            return StatusCode(code, response);
        }

        [HttpPost("contact")]
        public ActionResult ContactUs(SendEmailRequest emailService)
        {
            int code = 200;
            BaseResponse response = null;
            try
            {
                _service.ContactUs(emailService);
                code = 200;
                response = new SuccessResponse();
            }
            catch (Exception e)
            {
                Debug.Print("Error sending test email: " + e.Message);
                code = 500;
                response = new ErrorResponse("Error sending test email: " + e.Message);
            }
            return StatusCode(code, response);
        }
    }
}

