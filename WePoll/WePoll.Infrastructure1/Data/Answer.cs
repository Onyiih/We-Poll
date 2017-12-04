using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WePoll.Infrastructure1.Data
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string Content { get; set; }
        public int QuestionId { get; set; }

        //Relationship
        public virtual Question Question { get; set; }

    }
}
