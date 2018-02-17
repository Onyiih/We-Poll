using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WePoll.Domain.Managers;
using WePoll.Infrastructure.Services;

namespace WePoll.Controllers
{
    public class VoteController : Controller
    {
        private PollManager _poll;
        private VoteService _vote;

        //public VoteController()
        //{
        //    var pollRepo = new Po
        //}
        // GET: Vote
        public ActionResult Index()
        {
            return View();
        }
    }
}