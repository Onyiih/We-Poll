using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WePoll.Domain.Models
{
    public class ResponseModel : Model
    {
        public int ResponseId { get; set; }
        public int PollId { get; set; }
        public string Option { get; set; }
        public int Count { get; set; }
        public string Email { get; set; }

    }
}
