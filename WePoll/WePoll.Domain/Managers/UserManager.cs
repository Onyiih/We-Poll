using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WePoll.Domain.Models;

namespace WePoll.Domain.Managers
{
    public class UserManager
    {
        public UserModel Register(UserModel user)
        {
            //Validate user
            user.Validate();

            //Check if user already exists

            //Create user
            return user;
        }
    }
}
