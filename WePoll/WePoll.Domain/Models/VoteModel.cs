using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WePoll.Domain.Models
{
    public class VoteModel : Model
    {
        public int RespondentId { get; set; }
        public int OptionId { get; set; }
        public virtual RespondentModel Respondent { get; set; }
        public virtual OptionModel Option { get; set; }
    }
}