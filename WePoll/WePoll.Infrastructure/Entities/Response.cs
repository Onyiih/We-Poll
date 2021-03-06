﻿using System;
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
        public int ResponseId { get; set; }
        public string Option { get; set; }
        public int Count { get; set; }

        public int PollId { get; set; }
        public virtual Poll Poll { get; set; }
    }
}
