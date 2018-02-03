using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WePoll.Domain.Models;

namespace WePoll.Domain.Interface.Repositories
{
    public interface IPollRepository
    {
        PollModel[] GetPollWithReponses();
        PollModel GetPoll(int pollId);
        PollModel[] GetPolls();
        bool AddPoll(PollModel model);
        bool UpdatePoll(PollModel model);
    }
}
