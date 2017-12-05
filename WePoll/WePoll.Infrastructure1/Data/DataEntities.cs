using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WePoll.Infrastructure1.Data
{
    public class DataEntities: DbContext
    {
        public DbSet<Initiator> Initiators { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Respondent> Respondents { get; set; }
    }
}
