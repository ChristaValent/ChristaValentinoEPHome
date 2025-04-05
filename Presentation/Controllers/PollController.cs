using DataAccess.DataContext;
using DataAccess.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class PollController : Controller
    {
        public IActionResult Index([FromServices] PollRepository pollRepository)
        {
            var polls = pollRepository.GetPolls().OrderByDescending(p => p.DateCreated).ToList();

            return View(polls);
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreatePoll()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreatePoll(CreatePollViewModel model, [FromServices] PollRepository pollRepository)
        {
            if (ModelState.IsValid)
            {
                var poll = new Poll
                {
                    Title = model.Title,
                    Option1Text = model.Option1Text,
                    Option2Text = model.Option2Text,
                    Option3Text = model.Option3Text,
                    DateCreated = DateTime.Now
                };
                pollRepository.CreatePoll(poll);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Vote(int pollId, [FromServices] PollRepository pollRepository)
        {
            var poll = pollRepository.GetPolls().FirstOrDefault(p => p.Id == pollId);
            if (poll == null)
            {
                return RedirectToAction("Index");
            }

            return View(poll);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Vote(int pollId, int option, [FromServices] PollRepository pollRepository, [FromServices] VoteRepository voteRepository, [FromServices] UserManager<IdentityUser> user)
        {
            if(option >= 1)
            {
                var hasVotedSuccessfully = pollRepository.Vote(pollId, option);
                if (hasVotedSuccessfully)
                {
                    var vote = new Vote()
                    {
                        PollId = pollId,
                        VoterId = user.GetUserId(User),
                        VotedAt = DateTime.Now
                    };
                    voteRepository.CreateVote(vote);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Index");
        }

    }
}
