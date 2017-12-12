using System;
using System.Collections.Generic;

namespace WePoll.Infrastructure.Entities
{
    public class Poll
    {
        public int PollId { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Option> Options { get; set; } = new HashSet<Option>(); 
        public virtual ICollection<Respondent> Respondents { get; set; } = new HashSet<Respondent>();

    }
}