using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WePoll.Domain.Models
{
    public class RespondentModel
    {
        public int RespondentId { get; set; }
        public int UserId { get; set; }
        public int PollId { get; set; }
        public virtual UserModel User { get; set; }
        public virtual VoteModel Vote { get; set; }
        public virtual PollModel Poll { get; set; }
    }
}