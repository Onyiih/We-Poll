using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WePoll.Domain.Models
{
    public class PollModel
    {
        public int PollId { get; set; }
        public string Idea { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<OptionModel> Options { get; set; } = new HashSet<OptionModel>();
        public virtual ICollection<RespondentModel> Respondents { get; set; } = new HashSet<RespondentModel>();

        //Added Votes here because it makes our business logic happy. 
        //Logically speaking, we talk about polls and votes as directly related
        public virtual ICollection<VoteModel> Votes { get; set; } = new HashSet<VoteModel>();
    }
}