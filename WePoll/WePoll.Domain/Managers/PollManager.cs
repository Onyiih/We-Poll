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
      
       
        public PollModel[] GetPolls()
        {
            return _poll.GetPolls();
        }

        public void SavePoll(PollModel model)
        {
            if (model.PollId >= 0)
                _poll.AddPoll(model);
            else
                _poll.UpdatePoll(model);
        }

        /// <summary>
        /// Displays a Poll by it's Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PollModel DisplayPoll(int id)
        {
           return  _poll.DisplayPoll(id);
        }
    }
}
