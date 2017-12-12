using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WePoll.Domain.Models;
using WePoll.Infrastructure.Entities;

namespace WePoll.Infrastructure.Repositories
{
    public class PollRepository
    {
        /// <summary>
        /// Gets Polls with Votes greater than Zero
        /// </summary>
        /// <returns></returns>
        public PollModel[] GetPollWithVotes()
        {
            using (var context = new DataEntities())
            {
                var query = from poll in context.Polls
                            where poll.
            }
        }
    }
}
