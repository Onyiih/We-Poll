using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WePoll.Domain.Models;

namespace WePoll.Domain.Interface.Repositories
{
    public interface IResponseRepository
    {
        void AddResponse(ResponseModel model, int pollId);
        Dictionary<string, int> GetResponses(int pollId);
    }
}
