using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WePoll.Infrastructure1.Data
{
    public class Respondent
    {
        [Key,ForeignKey("User")]
        public int UserId { get; set; }
        public int AnswerId { get; set; }
        //Relationship
        public virtual User User { get; set; }
        public virtual Answer Answer { get; set; }


    }
}