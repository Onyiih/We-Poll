using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WePoll.Infrastructure.Entities
{
    public class DataEntities: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Respondent> Respondents { get; set; }
        public DbSet<Response> Responses { get; set; } 
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Option> Options { get; set; }
    }
}
