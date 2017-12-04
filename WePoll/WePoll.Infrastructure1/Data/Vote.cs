using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WePoll.Infrastructure1.Data
{
    public class Vote
    {
        public int VoteId { get; set; }
        public DateTime DateVoted { get; set; }
        public int Count { get; set; }

        public int AnswerId { get; set; }

        public virtual Answer Answer { get; set; }
    }
}