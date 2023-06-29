public class NewsletterSubscriptionService : INewsletterSubscriptionService
{
    IDataProvider _data = null;

    public NewsletterSubscriptionService(IDataProvider data)
    {
        _data = data;
    }

    public NewsletterSubscription GetByEmail(string Email)
    {
        string procName = "[dbo].[NewsLetterSubscriptions_Select_ByEmail]";
        NewsletterSubscription news = null;
        _data.ExecuteCmd(procName, delegate (SqlParameterCollection paramCollection)
        {
            paramCollection.AddWithValue("@Email", Email);
        }, delegate (IDataReader reader, short set)
        {
            int startingIndex = 0;
            news = MapNewsletterSubscriptions(reader , ref startingIndex);
        }
        );
        return news;
    }

    public Paged<NewsletterSubscription> GetAllPaginated(int pageIndex, int pageSize, bool? all = null)
    {
        string procName = "[dbo].[NewsLetterSubscriptions_SelectAll]";
        List<NewsletterSubscription> newsList = null;
        int totalCount = 0;
        Paged<NewsletterSubscription> pagedList = null;

        _data.ExecuteCmd(procName, delegate (SqlParameterCollection paramCollection)
        {
            paramCollection.AddWithValue("@PageIndex", pageIndex);
            paramCollection.AddWithValue("@PageSize", pageSize);
            paramCollection.AddWithValue("@All", all);
        }, delegate (IDataReader reader, short set)
        {
            int startingIndex = 0;

            if (newsList == null)
            {
                newsList = new List<NewsletterSubscription>();
            }

            NewsletterSubscription news = MapNewsletterSubscriptions(reader, ref startingIndex);
            totalCount = reader.GetSafeInt32(startingIndex++);
            newsList.Add(news);
        });

        if (newsList != null)
        {
            pagedList = new Paged<NewsletterSubscription>(newsList, pageIndex, pageSize, totalCount);
        }

        return pagedList;
    }

    public Paged<NewsletterSubscription> SearchPaginated(int pageIndex, int pageSize, bool all, string query)
    {
        string procName = "[dbo].[NewsLetterSubscriptions_SearchPagination]";
        List<NewsletterSubscription> newsList = null;
        int totalCount = 0;
        Paged<NewsletterSubscription> pagedList = null;

        _data.ExecuteCmd(procName, delegate (SqlParameterCollection paramCollection)
        {
            paramCollection.AddWithValue("@PageIndex", pageIndex);
            paramCollection.AddWithValue("@PageSize", pageSize);
            paramCollection.AddWithValue("@Query", query);
            paramCollection.AddWithValue("@All", all);
        }, delegate (IDataReader reader, short set)
        {
            int startingIndex = 0;

            if (newsList == null)
            {
                newsList = new List<NewsletterSubscription>();
            }

            NewsletterSubscription news = MapNewsletterSubscriptions(reader, ref startingIndex);
            totalCount = reader.GetSafeInt32(startingIndex++);
            newsList.Add(news);
        });

        if (newsList != null)
        {
            pagedList = new Paged<NewsletterSubscription>(newsList, pageIndex, pageSize, totalCount);
        }

        return pagedList;
    }


    public List<NewsletterSubscription> GetAllSubscribed()
    {
        string procName = "[dbo].[NewsLetterSubscriptions_SelectAll_Subscribed]";
        List<NewsletterSubscription> newsList = null; 

        _data.ExecuteCmd(procName, null, delegate (IDataReader reader, short set)
        {
            int startingIndex = 0;

            if (newsList == null)
            {
                newsList = new List<NewsletterSubscription>();
            }

            NewsletterSubscription news = MapNewsletterSubscriptions(reader, ref startingIndex);
            newsList.Add(news);
        });

        return newsList;
    }

    public void Add(NewsletterSubscriptionAddRequest model)
    {
        string procName = "[dbo].[NewsletterSubscriptions_Insert]";

        _data.ExecuteNonQuery(procName, inputParamMapper: delegate (SqlParameterCollection col)
        {
            AddCommonParams(model, col);

        });
    }

    public void Update(NewsletterSubscriptionAddRequest model)
    {
        string procName = "dbo.NewsLetterSubscriptions_Update";

        _data.ExecuteNonQuery(procName, inputParamMapper: delegate (SqlParameterCollection col)
        {
            AddCommonParams(model, col);
        });
    }

    private static NewsletterSubscription MapNewsletterSubscriptions(IDataReader reader, ref int startingIndex)
    {
        NewsletterSubscription news = new NewsletterSubscription();

        news.Email = reader.GetSafeString(startingIndex++);
        news.IsSubscribed = reader.GetSafeBool(startingIndex++);
        news.DateCreated = reader.GetSafeDateTime(startingIndex++);
        news.DateModified = reader.GetSafeDateTime(startingIndex++);
        return news;
    }

    private static void AddCommonParams(NewsletterSubscriptionAddRequest model, SqlParameterCollection col)
    {
        col.AddWithValue("@Email", model.Email);
        col.AddWithValue("@IsSubscribed", model.IsSubscribed);
    }
}
