using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voting_App2.Models.Entities;
using VOTING_APP2.Dtos;
using VOTING_APP2.Implementation.Repositories;
using VOTING_APP2.Interfaces.Services;
using VOTING_APP2.Models.Entities;
using VOTING_APP2.ontext;

namespace VOTING_APP2.Implementations.Services
{
    public class VoterService : IVoterService
    {
        UserRepository userRepository = new UserRepository();
        VoterRepository voterRepository = new VoterRepository();
        VoteContext context = new VoteContext();
        public Voter Create(VoterRequestModel model)
        {
            var existing = context.Voters.FirstOrDefault(a => a.UserEmail == model.UserEmail);
            if (existing != null)
            {
                System.Console.WriteLine("Sorry Voter with userEmail already exists");
                throw new DuplicateItemException();
            }
             var voter = new Voter()
             {
                Age = model.Age,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                Phonenumber = model.Phonenumber,
                UserEmail = model.UserEmail,
                Role = "Voter", 
                        
             };
             var user = new User()
             {
                 Password = model.Password,
                  Role = "Voter",
                   UserEmail = model.UserEmail,
             };
            voterRepository.Create(voter);
            userRepository.Create(user);
            return voter;
        }
    }
}