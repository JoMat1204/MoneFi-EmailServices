using sib_api_v3_sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using System.ComponentModel.DataAnnotations;

namespace Sabio.Models.Domain
{
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
}
