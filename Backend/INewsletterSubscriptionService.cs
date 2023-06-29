public interface INewsletterSubscriptionService
{
    void Add(NewsletterSubscriptionAddRequest model);
    Paged<NewsletterSubscription> GetAllPaginated(int pageIndex, int pageSize, bool? all = null);
    Paged<NewsletterSubscription> SearchPaginated(int pageIndex, int pageSize, bool all, string query);
    List<NewsletterSubscription> GetAllSubscribed();
    NewsletterSubscription GetByEmail(string Email);
    void Update(NewsletterSubscriptionAddRequest model);
}
