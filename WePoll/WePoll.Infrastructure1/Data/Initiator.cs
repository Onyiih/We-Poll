using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WePoll.Infrastructure1.Data
{
    public class Initiator
    {
        [Key,ForeignKey("User")]
        public int UserId { get; set; }
        
        //Relationships
        public virtual User User { get; set; }
        public virtual ICollection<Question> Questions { get; set; } = new HashSet<Question>();
        public virtual ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
    }
}
