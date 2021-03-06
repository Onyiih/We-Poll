﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WePoll.Domain.Interface.Repositories;
using WePoll.Domain.Models;

namespace WePoll.Tests.Mock.Repositories
{
    class MockPollRepository : IPollRepository
    {
        public bool AddPoll(PollModel model)
        {
            throw new NotImplementedException();
        }

        public PollModel DisplayPoll(int pollId)
        {
            throw new NotImplementedException();
        }

        public PollModel GetPollById(int pollId)
        {
            throw new NotImplementedException();
        }

        public PollModel[] GetPolls()
        {
            throw new NotImplementedException();
        }

        public PollModel[] GetPollWithReponses() => new[]
            {
                new PollModel
                {
                    PollId = 1,
                    Text = "Christmas Party should hold at a private beach. Yay or Nay?",
                    DateCreated = DateTime.Today
                }
            };

        public bool UpdatePoll(PollModel model)
        {
            throw new NotImplementedException();
        }

        //void IPollRepository<void>.AddPoll(PollModel model)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
