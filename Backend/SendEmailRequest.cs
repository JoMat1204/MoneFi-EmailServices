public class SendEmailRequest
{
  [Required]
  public EmailInfo Sender { get; set; }
  [Required]
  public EmailInfo To { get; set; }
  [Required]
  public string Subject { get; set; }
  [Required]
  public string Body { get; set; }
}
