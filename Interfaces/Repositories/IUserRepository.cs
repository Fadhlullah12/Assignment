using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VOTING_APP2.Models.Entities;

namespace VOTING_APP2.Interfaces.Repositories
{
    public interface IUserRepository
    {
      User Login (string UserEmail, string Password);
    }
}