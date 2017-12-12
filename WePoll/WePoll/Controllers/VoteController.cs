using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WePoll.Controllers
{
    public class VoteController : Controller
    {
        public ActionResult Vote()
        {
            return Content("You have successfully cast a vote");
        }
    }
}