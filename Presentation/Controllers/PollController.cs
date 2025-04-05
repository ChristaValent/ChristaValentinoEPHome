using DataAccess.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class PollController : Controller
    {
        PollRepository _pollRepository;

        public PollController(PollRepository pollRepository)
        {
            _pollRepository = pollRepository;
        }

        public IActionResult Index()
        {
            var polls = _pollRepository.GetPolls().OrderByDescending(p => p.DateCreated).ToList();

            //var pollListViewModel = polls.Select(p => new PollListViewModel
            //{
            //    Title = p.Title,
            //    Option1Text = p.Option1Text,l-ammont ta 
            //    Option2Text = p.Option2Text,
            //    Option3Text = p.Option3Text,
            //    CreatedAt = p.CreatedAt
            //}).ToList();
            return View(polls);
        }

        [HttpGet]
        public IActionResult CreatePoll()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePoll(CreatePollViewModel model)
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
                _pollRepository.CreatePoll(poll);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
