using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WePoll.Domain.Models;

namespace WePoll.Infrastructure.Services
{
    public class VoteService
    {
        public static string Key = "Vote";


        public VoteService()
        {
            if(HttpContext.Current.Session[Key] == null)
            {
                //HttpContext.Current.Session[Key] = new List<VoteModel>();
            }
        }

        //public List<VoteModel> GetVoteTally()
        //{
        //    return HttpContext.Current.Session[Key] as List<VoteModel>;
        //}

        //public void AddYesVotes()
        //{
            
        //}

        public void AddNoVotes()
        {

        }

        public void RemoveYesVote()
        {

        }

        public void RemoveNoVotes()
        {

        }

        public void ClearVotes()
        {

        }
    }
}