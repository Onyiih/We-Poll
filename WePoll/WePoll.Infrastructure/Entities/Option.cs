using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WePoll.Infrastructure.Entities
{
    public class Option
    {
        public int OptionId { get; set; }
        public string Text { get; set; }
        public int PollId { get; set; }
        public DateTime DateCreated { get; set; } 

        public virtual Poll Poll { get; set; }
        public ICollection<Vote> Votes { get; set; } = new HashSet<Vote>();
    }
}
