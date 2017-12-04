using System.Collections.Generic;

namespace WePoll.Infrastructure1.Data
{
    public class Poll
    {
        public int PollId { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
        public virtual ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
        public virtual ICollection<Respondent> Respondents { get; set; } = new HashSet<Respondent>();

    }
}