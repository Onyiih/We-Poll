using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WePoll.Domain.Managers;
using WePoll.Domain.Models;
using WePoll.Infrastructure.Entities;
using WePoll.Infrastructure.Repositories;
using WePoll.Models;

namespace WePoll.Controllers
{
    public class PollController : Controller
    {
        private PollManager _poll;
        private ResponseManager _response;
        private DataEntities _data = new DataEntities();

        public PollController()
        {
            var pollRepo = new PollRepository(_data);
            _poll = new PollManager(pollRepo);
            _response = new ResponseManager(new ResponseRepository(_data));
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
        public ActionResult Create([Bind(Include = "Text, DateCreated")]PollModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _poll.SavePoll(model);
                    _data.SaveChanges ();
                    return RedirectToAction("Polls");
                }
                //if (model != null)
                //{
                //    _poll.SavePoll(model);

                //    return RedirectToAction("Polls");

                //}
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }
            return View(model);
        }

        //[HttpGet]
        //public ActionResult Delete(int? id, bool? saveChangesError = false)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    if (saveChangesError.GetValueOrDefault())
        //    {
        //        ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists, contact your system administrator.";
        //    }
        //    Poll poll = _poll.DisplayPoll(id);
        //    if (poll == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(poll);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        Poll poll = _poll.DisplayPoll(id);
        //        _poll.
        //    }
        //}

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

        public ActionResult Details(int id)
        {

            var model = _poll.DisplayPoll(id);

            return View(model);
        }




        public ActionResult Vote(int id)
        {
            //Get the poll
            var poll = _poll.DisplayPoll(id);
            var model = new VoteViewModel
            {
                PollId = poll.PollId,
                Text = poll.Text,
                Responses = poll.Responses
            };

            //pass it to the view
            return View(model);
        }

        [HttpPost]
        public ActionResult Vote(VoteViewModel model)
        {
            //Get Poll
            var poll = _poll.DisplayPoll(model.PollId);
            model.Text = poll.Text;
            model.Responses = poll.Responses;


            if (ModelState.IsValid)
            {
                //Get posted Values and save to database
                var response = new ResponseModel
                {

                    PollId = model.PollId,
                    Option = model.Option,
                    Email = model.Email,

                };
                _response.AddResponse(response, poll.PollId);
                return RedirectToAction("details", new { id = poll.PollId});
            }

            return View(model);


        }
    }
}