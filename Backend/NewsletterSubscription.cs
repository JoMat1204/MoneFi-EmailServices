public class NewsletterSubscription 
{
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [StringLength(255)]
    public string Email { get; set; }
    public bool IsSubscribed { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}
