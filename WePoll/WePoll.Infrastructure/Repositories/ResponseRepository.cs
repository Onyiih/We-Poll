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
    public class ResponseRepository : IResponseRepository
    {
        private DbContext _context;

        public ResponseRepository(DbContext context)
        {
            _context = context;
        }
        public void AddResponse(ResponseModel model, int pollId)
        {
            //get poll
            var poll = _context.Set<Poll>().Find(pollId);


            //Check if email address already exists
            if (poll.Emails.Contains(model.Email))
            {
                throw new Exception("This email has been used for voting");
            }
            //Check if option exists
            var query = from r in _context.Set<Response>()
                        where r.Option == model.Option
                        where r.PollId == pollId
                        select r;

            var record = query.FirstOrDefault();


            //if record is null create it
            if(record == null)
            {
                var item = new Response
                {
                    PollId = pollId,
                    Option = model.Option,
                    Count = 1,
                };

                //Add email to list of emails in poll
                poll.Emails.Add(model.Email);

                var entry = _context.Entry(poll);
                entry.State = EntityState.Modified;
                _context.Set<Response>().Add(item);
                _context.SaveChanges();

            }

            //else update count
            else
            {
                //increment count
                record.Count += 1;
                //add email
                poll.Emails.Add(model.Email);

                //Saving changes
                var entryResponse = _context.Entry(record);
                entryResponse.State = EntityState.Modified;

                var entryPoll = _context.Entry(poll);
                entryPoll.State = EntityState.Modified;
                _context.SaveChanges();

            }




        }


        public Dictionary<string, int> GetResponses(int pollId)
        {
            throw new NotImplementedException();
        }
    }
}
