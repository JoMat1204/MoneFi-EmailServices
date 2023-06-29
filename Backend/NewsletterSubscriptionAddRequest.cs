public class NewsletterSubscriptionAddRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public bool IsSubscribed { get; set; }
}                                                
