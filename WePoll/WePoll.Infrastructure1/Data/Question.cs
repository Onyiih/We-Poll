using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WePoll.Infrastructure1.Data
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; } 

        //Relationship
        public virtual ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
        public virtual ICollection<Respondent> Respondents { get; set; } = new HashSet<Respondent>();
    }
}
