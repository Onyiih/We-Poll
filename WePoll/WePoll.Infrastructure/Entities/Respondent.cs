using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WePoll.Infrastructure.Entities
{
    public class Respondent
    {
        [Key]
        public int RespondentId { get; set; }
        public int UserId { get; set; }
        public int PollId { get; set; }
        public virtual User User { get; set; }
        public virtual Poll Poll { get; set; }
    }
}