using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WePoll.Domain.Models;

namespace WePoll.Domain.Managers
{
    public class PollManager
    {
        public PollManager()
        {

        }
        /// <summary>
        /// This returns all votes
        /// </summary>
        /// <returns>Array of Votes</returns>
        public PollModel[] ViewPoll()
        {
            return new PollModel[] { };
        }
    }
}
