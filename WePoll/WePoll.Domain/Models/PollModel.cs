using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WePoll.Domain.Models
{
    public class PollModel
    {
        public int PollId { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<OptionModel> Options { get; set; } = new HashSet<OptionModel>();
        public virtual ICollection<RespondentModel> Respondents { get; set; } = new HashSet<RespondentModel>();
    }
}