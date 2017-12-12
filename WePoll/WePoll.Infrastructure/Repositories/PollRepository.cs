using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WePoll.Domain.Models;
using WePoll.Infrastructure.Entities;

namespace WePoll.Infrastructure.Repositories
{
    public class PollRepository
    {
        /// <summary>
        /// Gets Polls with Votes greater than Zero
        /// </summary>
        /// <returns></returns>
        public PollModel[] GetPollWithVotes()
        {
            using (var context = new DataEntities())
            {
                //Query the Database and pull out the polls
                var query = from poll in context.Polls

                            //Inner query to pull out the vote for reach respondent to the poll
                            let votes = from respondent in poll.Respondents
                                        select respondent.Vote

                            //Select out the poll and corresponding votes
                            select new
                            {
                                poll,
                                votes
                            };

                //Execute query against the database and pull out the records
                var records = query.ToList();


                //Query to transfrom the entities to business objects (Models)
                var transform = from record in records

                                //Like the query above, convert the Votes to VoteModels
                                let votes = from vote in record.votes
                                            select new VoteModel
                                            {
                                                OptionId = vote.OptionId,
                                                RespondentId = vote.RespondentId,
                                            }

                                //Convert each poll to PollModel
                                select new PollModel
                                {
                                    DateCreated = record.poll.DateCreated,
                                    PollId = record.poll.PollId,
                                    Text = record.poll.Text,
                                    Votes = votes.ToList()  //Use to list because votes has an ICollection and not just IEnumerable
                                };

                return transform.ToArray();
            }
        }
    }
}
