using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WePoll.Domain.Interface.Repositories;
using WePoll.Domain.Models;

namespace WePoll.Domain.Managers
{
    public class ResponseManager
    {
        private IResponseRepository _repo;

        public ResponseManager(IResponseRepository repo)
        {
            _repo = repo;
        }


        public void AddResponse(ResponseModel model, int pollId)
        {
            _repo.AddResponse(model, pollId);
        }

    }
}
