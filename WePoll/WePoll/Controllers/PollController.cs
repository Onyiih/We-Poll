using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WePoll.Domain.Managers;
using WePoll.Domain.Models;
using WePoll.Infrastructure.Entities;
using WePoll.Infrastructure.Repositories;

namespace WePoll.Controllers
{
    public class PollController : Controller
    {
        private PollManager _poll;
        public PollController()
        {
            var PollRepo = new PollRepository(new DataEntities());
            _poll = new PollManager(PollRepo);
        }
        public ActionResult Polls()
        {
            var polls = _poll.GetPolls().ToList();
            return View(polls);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new PollModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PollId, Idea, DateCreated")]PollModel model)
        {
            try
            {
                if (model != null)
                {
                    bool result = _poll.SavePoll(model);
                    if (result)
                    {
                        return RedirectToAction("Polls");
                    }
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }
            return View(model);
        }

        //[HttpGet]
        //public ActionResult Edit()
        //{
        //    if (model != null)
        //    {
        //        var detail = _poll.GetPoll(int pollId);
        //    }

        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Idea, DateCreated")]Poll poll)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var edit = _poll.GetPoll.
        //        }
        //    }
        //}

        public ActionResult Details(PollModel model)
        {
            if (model != null)
            {
                var detail = _poll.GetPollsWithResponses();
            }

            return View(model);
        }

        //public ActionResult YesVote() => Content("You have successfully cast a \"Yes\" vote!");
        //public ActionResult NoVote() => Content("You have successfully cast a \"No\" vote!");
    }
}