using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WePoll.Infrastructure.Entities
{
    public class Response
    {
        [Key]
        public int ResponseID { get; set; }
        public int OptionID { get; set; }
        public int RespondentID { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Option Option { get; set; }
        public virtual Respondent Respondent { get; set; }
    }
}
