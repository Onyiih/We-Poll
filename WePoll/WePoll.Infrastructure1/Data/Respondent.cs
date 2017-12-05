using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WePoll.Infrastructure1.Data
{
    public class Respondent
    {
        [Key]
        public int RespondentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public int AnswerId { get; set; }

        //Relationship
        public virtual Answer Answer { get; set; }


    }
}