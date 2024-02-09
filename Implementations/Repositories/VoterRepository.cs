using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voting_App2.Models.Entities;
using VOTING_APP2.Implementations.Repositories;
using VOTING_APP2.ontext;

namespace VOTING_APP2.Implementation.Repositories
{
    public class VoterRepository : IVoterRepository
    {
        VoteContext voteContext = new VoteContext();
        public Voter Create(Voter voter)
        {
          voteContext.Voters.Add(voter);
          voteContext.SaveChanges();
          return voter;
        }

        public List<Voter> GetAll()
        {
            return voteContext.Voters.ToList();
        }
        public Voter GetVoter(string userEmail)
        {
            return voteContext.Voters.FirstOrDefault(a => a.UserEmail == userEmail)!;
        }

        public Voter Update(Voter voter)
        {
           voteContext.Voters.Update(voter);
           voteContext.SaveChanges();
           return voter;
        }
    }
}