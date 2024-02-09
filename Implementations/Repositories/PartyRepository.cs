using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voting_App2.Models.Entities;
using VOTING_APP2.Dtos;
using VOTING_APP2.Implementations.Repositories;
using VOTING_APP2.ontext;

namespace VOTING_APP2.Implementation.Repositories
{
    public class PartyRepository : IPartyRepository
    {
        VoteContext context = new VoteContext();
        public Party Create(Party party)
        {
            context.Parties.Add(party);
            context.SaveChanges();
            return party;
        }

        public List<Party> GetAll()
        {
            return context.Parties.ToList();
        }

        public List<ViewPartyContestant> GetContestants(string party)
        {
           return context.Contestants.Where(a => a.Party == party)
           .Select(a => new ViewPartyContestant()
           {
                Age = a.Age,
                Count = a.Count,
                FullName = $"{a.FirstName} {a.LastName}",
                Phonenumber = a.Phonenumber,
                UserEmail = a.UserEmail,
                Position = a.Position
           }).ToList();
        }

        public Party Update(Party party)
        {
            context.Parties.Update(party);
            context.SaveChanges();
            System.Console.WriteLine("Parties updated successfully");
            return party;
        }
    }
}