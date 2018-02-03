using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WePoll.Domain.Interface.Repositories;
using WePoll.Domain.Models;

namespace WePoll.Domain.Managers
{
    public class PollManager
    {
        private IPollRepository _poll;

        public PollManager(IPollRepository poll)
        {
            _poll = poll;
        }
        /// <summary>
        /// This returns all votes
        /// </summary>
        /// <returns>Array of Votes</returns>
        public PollModel[] GetPollsWithResponses()
        {
            return _poll.GetPollWithReponses();
        }
        
        public PollModel GetPoll(int pollId)
        {
            return _poll.GetPoll(pollId);
        }
        public PollModel[] GetPolls()
        {
            return _poll.GetPolls();
        }

        public bool SavePoll(PollModel model)
        {
            if (model.PollId >= 0)
                return _poll.AddPoll(model);
            else
                return _poll.UpdatePoll(model);
        }
    }
}
