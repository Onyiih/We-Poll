using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WePoll.Infrastructure.Entities;

namespace WePoll.Infrastructure.Entities
{
    public class Vote
    {
        [Key, ForeignKey("Respondent")]
        public int RespondentId { get; set; }
        public int OptionId { get; set; }
        public virtual Respondent Respondent { get; set; }
        public virtual Option Option { get; set; }
    }
}
