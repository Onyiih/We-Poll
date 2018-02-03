using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WePoll.Controllers
{
    public class VoteController : Controller
    {
        public ActionResult YesVote() => Content("You have successfully cast a \"Yes\" vote!");
        public ActionResult NoVote() => Content("You have successfully cast a \"No\" vote!");
    }
}