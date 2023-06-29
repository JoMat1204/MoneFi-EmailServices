    public class SenderEmail
    {
        [Required]
        [EmailAddress]
        public SendSmtpEmailSender Sender { get; set; }
        [Required]
        [EmailAddress]
        public List<SendSmtpEmailTo> To { get; set; }
        [Required]
        [EmailAddress]
        public List<SendSmtpEmailBcc> Bcc { get; set; }
        public string Body { get; set; }
        public string Name { get; set; }
        public string HtmlContent { get; set; }
    }
