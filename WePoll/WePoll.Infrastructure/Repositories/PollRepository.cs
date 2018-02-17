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
                Idea = model.Idea, DateCreated = DateTime.Now,
                Options = model.Options.Select(p => new Option
                {
                    Idea = p.Idea, PollId = p.PollId
                }).ToList()
            };

            _context.Set<Poll>().Add(poll);
            return _context.SaveChanges() > 0 ? true : false; 
        }

        public PollModel GetPollById(int pollId)
        {
            var model = _context.Set<Poll>().SingleOrDefault(p => p.PollId == pollId);
            return new PollModel
            {
                PollId = model.PollId,
                DateCreated = model.DateCreated,
                Idea = model.Idea,
                Options = model.Options.Select(p => new OptionModel
                {
                    Idea = p.Idea,
                    DateCreated = p.DateCreated,
                    OptionId = p.OptionId
                }).ToList()
            };
        }

        public PollModel[] GetPolls()
        {
            var query = _context.Set<Poll>().Select(p => new PollModel
            {
                PollId = p.PollId,
                DateCreated = p.DateCreated,
                Idea = p.Idea,
                Options = p.Options.Select(t => new OptionModel
                {
                    Idea = t.Idea,
                    DateCreated = t.DateCreated,
                    OptionId = t.OptionId
                }).ToList()
            });
            return query.ToArray();
        }

        /// <summary>
        /// Gets Polls with Votes greater than Zero
        /// </summary>
        /// <returns></returns>
        public PollModel[] GetPollWithReponses()
        {

            var query = from r in _context.Set<Response>()
                        join o in _context.Set<Option>() on r.OptionID equals o.OptionId
                        join p in _context.Set<Poll>() on o.PollId equals p.PollId
                        select new PollModel
                        {
                            PollId = p.PollId, DateCreated = p.DateCreated, Idea = p.Idea,
                            Options = (from os in _context.Set<Option>()
                                       where os.PollId == p.PollId
                                       select new OptionModel
                                       {
                                           PollId = p.PollId, Idea = os.Idea, OptionId = os.OptionId
                                       }).ToList()
                        };

            return query.ToArray();

            //_context.Set<Poll>()
            ////using (var context = new DataEntities())
            ////{
            //    //Query the Database and pull out the polls
            //    var query = from poll in _context.Set<Poll>()

                        //                //Inner query to pull out the vote for each respondent to the poll
                        //                let votes = from respondent in poll.Respondents
                        //                            select respondent.Vote

                        //                //Select out the poll and corresponding votes
                        //                select new
                        //                {
                        //                    poll,
                        //                    votes
                        //                };

                        //    //Execute query against the database and pull out the records
                        //    var records = query.ToList();


                        //    //Query to transfrom the entities to business objects (Models)
                        //    var transform = from record in records

                        //                    //Like the query above, convert the Votes to VoteModels
                        //                    let votes = from vote in record.votes
                        //                                select new VoteModel
                        //                                {
                        //                                    OptionId = vote.OptionId,
                        //                                    RespondentId = vote.RespondentId,
                        //                                }

                        //                    //Convert each poll to PollModel
                        //                    select new PollModel
                        //                    {
                        //                        DateCreated = record.poll.DateCreated,
                        //                        PollId = record.poll.PollId,
                        //                        Text = record.poll.Text,
                        //                        Votes = votes.ToList()  //Use to list because votes has an ICollection and not just IEnumerable
                        //                    };

                        //    return transform.ToArray();
                        //}
        }

        public bool UpdatePoll(PollModel model)
        {
            throw new NotImplementedException();
        }
    }
}
