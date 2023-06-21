using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Sabio.Services;
using Sabio.Web.Controllers;
using Sabio.Web.Models.Responses;
using Sabio.Models.Requests;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using Stripe;
using System.Collections.Generic;
using Sabio.Models;
using System.Reflection;
using Sabio.Models.Domain;

namespace Sabio.Web.Api.Controllers
{
    [Route("api/newsletters/subscriptions")]
    [ApiController]
    public class NewsletterSubscriptionsServiceApiController : BaseApiController
    {
        private INewsletterSubscriptionService _news = null;

        public NewsletterSubscriptionsServiceApiController(INewsletterSubscriptionService news, ILogger<NewsletterSubscriptionsServiceApiController> logger) : base(logger)
        {
            _news = news;
        }

        [HttpGet("{email}")]
        public ActionResult<ItemResponse<NewsletterSubscription>> GetByEmail(string email)
        {
            int code = 200;
            BaseResponse response = null;
            try
            {
                NewsletterSubscription news = _news.GetByEmail(email);
                if (news == null)
                {
                    code = 404;
                    response = new ErrorResponse("Application Resource not found");
                }
                else
                {
                    response = new ItemResponse<NewsletterSubscription> { Item = news };
                }
            }
            catch (Exception ex)
            {
                base.Logger.LogError(ex.ToString());
                code = 500;
                response = new ErrorResponse(ex.Message);
            }
            return StatusCode(code, response);
        }

        [HttpGet("paginate")]
        public ActionResult<ItemResponse<Paged<NewsletterSubscription>>> GetAllPaginated(int pageIndex, int pageSize, bool? all = null)
        {
            ActionResult<ItemResponse<Paged<NewsletterSubscription>>> result = null;
            try
            {
                Paged<NewsletterSubscription> pagedSubscriptions = _news.GetAllPaginated(pageIndex, pageSize, all);

                if (pagedSubscriptions == null)
                {
                    ErrorResponse errorResponse = new ErrorResponse("App Resource is not found.");
                    result = NotFound404(errorResponse);
                }
                else
                {
                    ItemResponse<Paged<NewsletterSubscription>> response = new ItemResponse<Paged<NewsletterSubscription>>();
                    response.Item = pagedSubscriptions;
                    result = Ok200(response);
                }
            }
            catch (Exception ex)
            {
                base.Logger.LogError(ex.ToString());
                result = StatusCode(500, new ErrorResponse(ex.Message));
            }

            return result;
        }

        [HttpGet("search")]
        public ActionResult<ItemResponse<Paged<NewsletterSubscription>>> SearchPagination(int pageIndex, int pageSize, bool all, string query)
        {
            ActionResult<ItemResponse<Paged<NewsletterSubscription>>> result = null;

            try
            {
                Paged<NewsletterSubscription> pagedSubscriptions = _news.SearchPaginated(pageIndex, pageSize, all, query);

                if (pagedSubscriptions == null)
                {
                    ErrorResponse errorResponse = new ErrorResponse("App Resource is not found.");
                    result = NotFound404(errorResponse);
                }
                else
                {
                    ItemResponse<Paged<NewsletterSubscription>> response = new ItemResponse<Paged<NewsletterSubscription>>
                    {
                        Item = pagedSubscriptions
                    };
                    result = Ok200(response);
                }
            }
            catch (Exception ex)
            {
                base.Logger.LogError(ex.ToString());
                result = StatusCode(500, new ErrorResponse(ex.Message));
            }

            return result;
        }


        [HttpGet("subscribed")]
        public ActionResult<ItemsResponse<NewsletterSubscription>> GetAllSubscribed()
        {
            ActionResult<ItemsResponse<NewsletterSubscription>> result = null;

            try
            {
                List<NewsletterSubscription> list = _news.GetAllSubscribed();
                if (list == null)
                {
                    ErrorResponse errorResponse = new ErrorResponse("App Resource is not found.");
                    result = NotFound404(errorResponse);
                }
                else
                {
                    ItemsResponse<NewsletterSubscription> response = new ItemsResponse<NewsletterSubscription>();
                    response.Items = list;
                    result = Ok200(response);
                }
            }
            catch (Exception ex)
            {
                base.Logger.LogError(ex.ToString());
                result = StatusCode(500, new ErrorResponse(ex.Message));
            }

            return result;
        }

        [HttpPost]
        public ActionResult<SuccessResponse> AddEmail(NewsletterSubscriptionAddRequest model)
        {
            ObjectResult result = null;

            try
            {
                _news.Add(model);
                ItemResponse<string> response = new ItemResponse<string>() { Item = model.Email };
                result = Created201(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                ErrorResponse response = new ErrorResponse(ex.Message);

                result = StatusCode(500, response);
            }

            return result;
        }

        [HttpPut]
        public ActionResult<SuccessResponse> UpdateEmail(NewsletterSubscriptionAddRequest model)
        {
            int code = 200;
            BaseResponse response = null;

            try
            {
                _news.Update(model);

                response = new SuccessResponse();
            }
            catch (Exception ex)
            {
                code = 500;
                response = new ErrorResponse(ex.Message);
                base.Logger.LogError(ex.ToString());
            }

            return StatusCode(code, response);
        }
    }
}
