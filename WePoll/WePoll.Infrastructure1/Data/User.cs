using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WePoll.Infrastructure1.Data
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        
        
        //Relationships
        public virtual Initiator Initiator { get; set; }
        public virtual Respondent Respondent { get; set; }
    }
}
