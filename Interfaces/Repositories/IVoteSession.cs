using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voting_App2.Models.Entities;
using VOTING_APP2.Models.Entities;

namespace VOTING_APP2.Implementations.Repositories
{
    public interface IVoteSessionRepository 
    {
        VoteSession Create(VoteSession session);
        // List<Contestant> GetAll();
        List<Contestant> GetAllContestants();
        List<Voter> GetAllVoters();
    }
}