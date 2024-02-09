using Microsoft.EntityFrameworkCore;
using Voting_App2.Models.Entities;
using VOTING_APP2.Dtos;
using VOTING_APP2.Implementations.Repositories;
using VOTING_APP2.Models.Entities;
using VOTING_APP2.ontext;

namespace VOTING_APP2.Implementation.Repositories
{
    public class VoteRepository : IVoteSessionRepository
    {
        VoteContext context = new VoteContext();
        public VoteSession Create(VoteSession session)
        {
            context.Sessions.Add(session);
            context.SaveChanges();
            return session;
        }

        public List<VoteSession> GetAll()
        {
           return context.Sessions.ToList();
           
        }

        public List<Contestant> GetAllContestants()
        {
           return context.Contestants.Where(x => x.IsVoting == true).ToList();
        }

        public List<Voter> GetAllVoters()
        {
            return context.Voters.Where(x => x.HasVoted == true).ToList();
        }
        
         public VoteSession GetCurrentSession()
        {
            return context.Sessions.FirstOrDefault(a => a.IsActive == true)!;
        }
         public Contestant GetContetantByTagNumber(string tag)
        {
            return context.Contestants.FirstOrDefault(a => a.VotingTag == tag)!;
        }
        
         public VoteSession Update(VoteSession session)
        {
            context.Sessions.Update(session);
            context.SaveChanges();
            return session;
        }
        /// <summary>
        /// DATA OPTIMIZATION USING SELECT WHAT IS NEEDED
        /// </summary>
        /// <returns></returns>
        public List<VoteResult> GetVoteResults()
        {
            var query = context.Contestants.Where(a => a.IsVoting == true)
            .Select(a => new VoteResult{
                Name = $"{a.FirstName} {a.LastName}",
                NumberOfVotes = a.Count,
                Party = a.Party,
                Position = a.Position
            }).OrderByDescending(a => a.NumberOfVotes)
            ;
            System.Console.WriteLine(query.ToQueryString());
            return query.ToList();
        }
    }
}