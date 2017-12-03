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
        public DbSet<User> Users { get; set; }
        public DbSet<Initiator> Initiators { get; set; }
    }
}
