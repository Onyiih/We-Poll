using System;
using System.Collections.Generic;

namespace WePoll.Infrastructure1.Data
{
    public class Poll
    {
        public int PollId { get; set; }
        public DateTime ResponseDate { get; set; }
        public int Count { get; set; }


        public virtual ICollection<Respondent> Respondents { get; set; } = new HashSet<Respondent>();

    }
}