using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WePoll.Domain.Interface.Repositories;
using WePoll.Domain.Models;
using WePoll.Infrastructure.Entities;

namespace WePoll.Infrastructure.Repositories
{
    public class PollRepository : IPollRepository
    {
        private DbContext _context;

        public PollRepository(DbContext context)
        {
            _context = context;
        }

        public bool AddPoll(PollModel model)
        {
            var poll = new Poll
            {
                Text = model.Text, DateCreated = DateTime.Now
            };

            _context.Set<Poll>().Add(poll);
            return _context.SaveChanges() > 0 ? true : false;
        }

        
        public PollModel[] GetPolls()
        {
            var query = _context.Set<Poll>().Select(p => new PollModel
            {
                PollId = p.PollId,
                DateCreated = p.DateCreated,
                Text = p.Text
            });
            return query.ToArray();
        }

        /// <summary>
        /// Gets Polls with Votes greater than Zero
        /// </summary>
        /// <returns></returns>
        public PollModel[] GetPollWithReponses()
        {

            var query = from p in _context.Set<Poll>()
                        //join r in _context.Set<Response>() on p.PollId equals r.PollId
                        select new PollModel
                        {
                            PollId = p.PollId, DateCreated = p.DateCreated, Text = p.Text
                        };

            return query.ToArray();
            
        }

        public bool UpdatePoll(PollModel model)
        {
            throw new NotImplementedException();
        }

        public PollModel DisplayPoll(int pollId)
        {
            //Get the poll by Id

            var query = from p in _context.Set<Poll>()
                        where p.PollId == pollId
                        let r = from res in _context.Set<Response>()
                                where res.PollId == pollId
                                select res
                        select new
                        {
                            p,
                            r
                        };



            var record = query.FirstOrDefault();

            var dict = new Dictionary<string, int>();
            foreach(var item in record.r.ToArray())
            {
                dict.Add(item.Option, item.Count);
            }
            var poll = new PollModel
            {
                PollId = record.p.PollId,
                Text = record.p.Text,
                DateCreated = record.p.DateCreated,
                Responses = dict                
            };

            return poll;
        }
    }
}
