using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VOTING_APP2.Dtos;
using VOTING_APP2.Implementation.Repositories;
using VOTING_APP2.Interfaces.Services;
using VOTING_APP2.Models.Entities;

namespace VOTING_APP2.Implementations.Services
{
    public class VotingService : IVotingService
    {
        VoteRepository voteRepository = new VoteRepository();
        public VoteSession Create(StartVotingRequestModel session)
        {
          var current = voteRepository.GetCurrentSession();
          if (current != null)
          {
            System.Console.WriteLine("Session already in progress");
            throw new DuplicateItemException();
          }
           var session2 = new VoteSession(){
             Position = session.Position
           };
          voteRepository.Create(session2);
          return session2;
        }
    }
}