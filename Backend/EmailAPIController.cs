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

