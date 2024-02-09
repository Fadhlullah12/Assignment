using Voting_App2.Models.Entities;
using VOTING_APP2.Dtos;
using VOTING_APP2.Implementation.Repositories;
using VOTING_APP2.Interfaces.Services;
using VOTING_APP2.Models.Entities;
using VOTING_APP2.ontext;

namespace VOTING_APP2.Implementations.Services
{
    public class ContestantService : IContestantService
    {
        VoteRepository voteRepository = new VoteRepository();
        UserRepository userRepository = new UserRepository();
        ContestantRepository contestantRepository = new ContestantRepository();
        VoteContext context = new VoteContext();
        PositionRepository positionRepository = new PositionRepository();
        public Contestant Create(CreateContestantRequestModel model)
        {
            var id = voteRepository.GetCurrentSession();
            var existingPosition = positionRepository.Get(model.Position);
            var existing = context.Contestants.FirstOrDefault(a => a.UserEmail == model.UserEmail);
            var existingposition = context.Contestants.FirstOrDefault(a => a.Position == model.Position && a.Party == model.Party);
            if (existing != null)
            {
                System.Console.WriteLine("Sorry contestant with userEmail already exists");
                throw new DuplicateItemException();
            }
            if (existingposition != null)
            {
                System.Console.WriteLine("Sorry contestant for position already exists with same party");
                throw new DuplicateItemException();
            }
            if (existingPosition == null)
            {
                System.Console.WriteLine("Sorry position does not exist"); 
                throw new DllNotFoundException();
            }
            var contestant = new Contestant()
            {
                VoteSessionId = id.Id,
                Age = model.Age,
                Count = 0,
                FirstName = model.FirstName,
                IsVoting = true,
                LastName = model.LastName,
                Phonenumber = model.Phonenumber,
                Party = model.Party,
                Position = model.Position,
                UserEmail = model.UserEmail,
                VotingTag =$"CNT{new Random().Next(100000)}",   
            };
            var user = new User()
            {
              Password  = model.Password,
              UserEmail = model.UserEmail,
              Role = "Contestant",
            };

            contestantRepository.Create(contestant);
            userRepository.Create(user);
            return contestant;
        }

    }
}