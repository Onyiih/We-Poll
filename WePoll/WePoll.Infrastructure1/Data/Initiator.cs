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
        [ForeignKey(User)]
        public int UserId { get; set; }
        public string Address { get; set; }
        
        //Relationships
        public virtual User User { get; set; }
    }
}
