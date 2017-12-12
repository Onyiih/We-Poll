using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WePoll.Domain.Managers;

namespace WePoll.Controllers
{
    public class HomeController : Controller
    {
        private PollManager _poll;

        public HomeController()
        {
            _poll = new PollManager();
        }
        public ActionResult Index()
        {
            var votes = _poll.ViewPoll();
            return View(votes);
        }
    }
}