using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WePoll.Domain.Models
{
    public class OptionModel
    {
        public int OptionId { get; set; }
        public string Text { get; set; }
        public int PollId { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual PollModel Poll { get; set; }
        public ICollection<VoteModel> Votes { get; set; } = new HashSet<VoteModel>();
    }
}