using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WePoll.Models
{
    public class VoteViewModel
    {
        public int PollId { get; set; }
        public string Text { get; set; }

        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Option { get; set; }
        public Dictionary<string, int> Responses { get; set; } = new Dictionary<string, int>();

    }
}