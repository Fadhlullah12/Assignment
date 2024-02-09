using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VOTING_APP2.Interfaces.Repositories;
using VOTING_APP2.Models.Entities;
using VOTING_APP2.ontext;

namespace VOTING_APP2.Implementations
{
    public class UserRepository : IUserRepository
    {
        VoteContext context = new VoteContext();
        public User Login(string UserEmail, string Password)
        {
           return context.Users.FirstOrDefault(a => a.UserEmail == UserEmail);
        }
         public User Create(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }
    }
}