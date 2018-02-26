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
        PollModel[] GetPolls();
        bool AddPoll(PollModel model);
        bool UpdatePoll(PollModel model);
        PollModel DisplayPoll(int pollId);
    }
}
