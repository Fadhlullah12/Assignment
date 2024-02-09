using Microsoft.EntityFrameworkCore;
using Voting_App2.Models.Entities;
using VOTING_APP2.Dtos;
using VOTING_APP2.Implementations.Repositories;
using VOTING_APP2.ontext;

namespace VOTING_APP2.Implementation.Repositories
{
    public class ContestantRepository : IContestantRepository
    {
        VoteContext context = new VoteContext();
        public Contestant Create(Contestant contestant)
        {
          context.Contestants.Add(contestant);
          context.SaveChanges();
          return contestant;
        }

        public List<Contestant> GetAll()
        {
            return context.Contestants.ToList();
        }

public Contestant Update(Contestant contestant)
{
    context.Contestants.Update(contestant);
    context.SaveChanges();
    return contestant;
}


        
    }
}