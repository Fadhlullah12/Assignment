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
    public class PositionRepository : IPositionRepository
    {
        VoteContext context = new VoteContext();
        public Position Create(Position position)
        {
            context.Positions.Add(position);
            context.SaveChanges();
            return position;
        }

        public List<Position> GetAll()
        {
           return context.Positions.ToList();
        }

        public List<ViewPositionContestants> GetContestants(string name)
        {
           return context.Contestants.Where(a => a.Position == name)
           .Select(a => new ViewPositionContestants()
           {
                Age = a.Age,
                Count = a.Count,
                FullName = $"{a.FirstName} {a.LastName}",
                Party = a.Party,
                Phonenumber = a.Phonenumber,
                UserEmail = a.UserEmail
           }).ToList();
        }
        public Position Get(string name)
        {
           return context.Positions.FirstOrDefault(a => a.PositionName == name)!;
        }

        public Position Update(Position position)
        {
            context.Positions.Update(position);
            context.SaveChanges();
            return position;
        }
    }
}