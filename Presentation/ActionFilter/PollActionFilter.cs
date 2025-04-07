using DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.ActionFilter
{
    public class PollActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            VoteRepository voteRepository = context.HttpContext.RequestServices.GetService<VoteRepository>();

            UserManager<IdentityUser> user = context.HttpContext.RequestServices.GetService<UserManager<IdentityUser>>();

            var userId = user.GetUserId(context.HttpContext.User);

            //get the pollId from the action arguments
            if (context.ActionArguments.TryGetValue("pollId", out var pollIdObj) && pollIdObj is int pollId)
            {
                if (voteRepository.HasVoted(userId, pollId))
                {
                    // Redirect to Index if already voted
                    context.Result = new RedirectToActionResult("Index", "Poll", null);
                }
            }

            base.OnActionExecuting(context);
        }
    }    
}
