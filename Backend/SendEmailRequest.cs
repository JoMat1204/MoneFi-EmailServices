using sib_api_v3_sdk.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabio.Models.Requests
{
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
}
