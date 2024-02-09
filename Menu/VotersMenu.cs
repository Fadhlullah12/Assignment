using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voting_App2.Models.Entities;
using VOTING_APP2.Implementation.Repositories;

namespace VOTING_APP2.Menu
{
    public class VotersMenu
    {
        VoteRepository voteRepository = new VoteRepository();
        ContestantRepository contestantRepository = new ContestantRepository();
        VoterRepository voterRepository = new VoterRepository();
        public  void VoterMenu(string userEmail)
        {
          var current = voteRepository.GetCurrentSession();
          if (current != null)
          {
            System.Console.WriteLine("Welcome");
            System.Console.WriteLine("Press 1 to view ongoing election\nPress 2 vote");
            int reponse = int.Parse(System.Console.ReadLine()!);
            if (reponse == 2)
            {
               var voter1 = voterRepository.GetVoter("bush@gmail.com");
               var hasVoted = voter1.HasVoted;            
          if (!hasVoted)
            {
               var contestants = voteRepository.GetAllContestants();
               foreach (var item in contestants)
               {
                 System.Console.WriteLine($"{item.FirstName} {item.LastName} {item.Age} {item.Phonenumber} {item.UserEmail} {item.Count} {item.Party} {item.VotingTag}");
               }
               System.Console.WriteLine("Enter the voting tag of the contestant you want to vote for");
               string tag = Console.ReadLine()!;
               var contestant = voteRepository.GetContetantByTagNumber(tag);
               var count = contestant.Count + 1;
                var contestant1 = new Contestant()
                {
                    Id = contestant.Id,
                    Age = contestant.Age,
                    Count = count,
                    IsVoting = true,
                    FirstName = contestant.FirstName,
                    LastName = contestant.LastName,
                    Party = contestant.Party,
                    Phonenumber = contestant.Phonenumber,
                    VotingTag = contestant.VotingTag,
                    Position = contestant.Position,
                    UserEmail = contestant.UserEmail,
                    VoteSessionId = contestant.VoteSessionId
                };
                var a = contestant1.Count;
                System.Console.WriteLine(a);
                contestantRepository.Update(contestant1);
                var voter = new Voter()
                {
                    Age = voter1.Age,
                    FirstName = voter1.FirstName,
                    HasVoted = voter1.HasVoted = true,
                    LastName = voter1.LastName,
                    Password = voter1.Password,
                    Phonenumber = voter1.Phonenumber,
                    Role = voter1.Role,
                    UserEmail = voter1.UserEmail,
                    DateCreated = voter1.DateCreated,
                    VoteSessionId = contestant.VoteSessionId,
                };
                voterRepository.Update(voter);
                System.Console.WriteLine("Thanks for your vote");
            }
            else
            {
                System.Console.WriteLine("Sorry you are not allowed to vote");
                VoterMenu( userEmail);
            }
              VoterMenu( userEmail);
          }
          if (reponse == 1)
          {
            int count2 = 0;
             VoteRepository voteRepository = new VoteRepository();
             foreach (var item in  voteRepository.GetVoteResults())
             {
                count2++;
                        if (count2 == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            System.Console.WriteLine($" {item.NumberOfVotes} {item.Party} {item.Name} {item.Position} ");
                            continue;
                        }
                        if (count2 == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            System.Console.WriteLine($" {item.NumberOfVotes} {item.Party} {item.Name} {item.Position}");
                            continue;
                        }
                        if (count2 == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            System.Console.WriteLine($" {item.NumberOfVotes} {item.Party} {item.Name} {item.Position}");
                            continue;
                        }
                            System.Console.WriteLine($" {item.NumberOfVotes} {item.Party} {item.Name} {item.Position}");
             }
             VoterMenu(userEmail);
          }
          }
          else
          {
            System.Console.WriteLine("No sessions available");
          }
        }
    }
}