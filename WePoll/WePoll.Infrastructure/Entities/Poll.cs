using System;
using System.Collections.Generic;

namespace WePoll.Infrastructure.Entities
{
    public class Poll
    {
        public int PollId { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<string> Emails { get; set; } = new HashSet<string>();
        public ICollection<Response> Responses { get; set; } = new HashSet<Response>();


        public virtual ICollection<string> RespondentIPs { get; set; } = new HashSet<string>();

    }
}