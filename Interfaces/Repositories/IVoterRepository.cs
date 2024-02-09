using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voting_App2.Models.Entities;

namespace VOTING_APP2.Implementations.Repositories
{
    public interface IVoterRepository
    {
        Voter Create(Voter voter);
        List<Voter> GetAll();
        Voter Update(Voter position);
    }
}