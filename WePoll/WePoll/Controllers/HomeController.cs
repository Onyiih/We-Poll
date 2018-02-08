using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WePoll.Domain.Managers;
using WePoll.Domain.Models;
using WePoll.Infrastructure.Entities;
using WePoll.Infrastructure.Repositories;
using WePoll.Infrastructure.Services;

namespace WePoll.Controllers
{
    public class HomeController : Controller
    {
        private PollManager _poll;
        private VoteService _vote;

        public HomeController()
        {
            var PollRepo = new PollRepository(new DataEntities());
            _poll = new PollManager(PollRepo);

            _vote = new VoteService();
        }
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Polls()
        //{
        //    var polls = _poll.GetPolls().ToList();
        //    return View(polls);
        //}

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    var model = new PollModel();
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult Create(PollModel model)
        //{
        //    if (model != null)
        //    {
        //        bool result = _poll.SavePoll(model);
        //        if (result)
        //        {
        //            return RedirectToAction("Polls");
        //        }
        //    }

        //    return View(model);
        //}
    }
}