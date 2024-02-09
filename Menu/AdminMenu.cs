using Voting_App2.Models.Entities;
using VOTING_APP2.Dtos;
using VOTING_APP2.Implementation.Repositories;
using VOTING_APP2.Implementations.Services;
using VOTING_APP2.Models.Entities;

namespace VOTING_APP2.Menu
{
    public class AdminMenu
    {
        public VoteRepository voteRepository = new VoteRepository();
        
        public  void SuperAdmin()
        {
            ContestantRepository contestantRepository = new ContestantRepository();
            System.Console.WriteLine("Welcome ");
            System.Console.WriteLine("Press 1 to visit contestant menu \nPress 2 to visit party menu \nPress 3 to visit position menu \nPress 4 to visit voting menu");  
            int reponse = int.Parse(Console.ReadLine()!);
            var currentSession = voteRepository.GetCurrentSession();
            switch (reponse)
            {
                case 1:
                if (currentSession != null)
                {
                    System.Console.WriteLine("Press 1 to register contestant\n Press 2 to view all contestant\nPress 3 to view contesting contestants");
                int reponse2 = int.Parse(Console.ReadLine()!);
                if (reponse2 == 1)
                {
                    RegisterContestant();
                    SuperAdmin();
                }
                 if (reponse2 == 2)
                {
                  foreach (var item in  contestantRepository.GetAll())
                  {
                    System.Console.WriteLine($"{item.FirstName} {item.LastName} {item.Age} {item.Phonenumber} {item.UserEmail} {item.Count} {item.Party}");
                  } 
                  SuperAdmin();
                }
                if (reponse2 == 3)
                {
                  VoteRepository voteRepository1 = new VoteRepository();
                  foreach (var item in  voteRepository1.GetAllContestants())
                  {
                    System.Console.WriteLine($"{item.FirstName} {item.LastName} {item.Age} {item.Phonenumber} {item.UserEmail} {item.Count} {item.Party} ");
                  } 
                  SuperAdmin();
                }
                }
                else
                {
                    System.Console.WriteLine("Please begin a session");
                    SuperAdmin();
                }
                break;

                case 2:
                if (currentSession != null)
                {
                    System.Console.WriteLine("Press 1 to register a party\n Press 2 to view all party members\nPress 3 view all parties\nPress 4 to update a party ");
                int response3 = int.Parse(Console.ReadLine()!);
                switch (response3)
                {
                    case 1 :
                     AdminMenu.RegisterParty();
                     SuperAdmin();
                     break;
                     case 2:
                     System.Console.WriteLine("Enter the party name");
                     string party = Console.ReadLine()!;
                     PartyRepository partyRepository = new PartyRepository();
                    var contestants2 =  partyRepository.GetContestants(party);
                    foreach (var item in contestants2)
                    {
                        System.Console.WriteLine($"{item.FullName} {item.Age} {item.Phonenumber} {item.UserEmail} {item.Count} {item.Position}");
                    }
                    SuperAdmin();
                     break;
                     case 3:
                     PartyRepository partyRepository2 = new PartyRepository();
                     var parties = partyRepository2.GetAll();
                     foreach (var item in parties)
                     {
                        System.Console.WriteLine($"Name :{item.Name} Symbol :{item.Symbol}");
                     }
                     SuperAdmin();
                     break;
                    
                     case 4:
                     System.Console.WriteLine("Enter the name of the party to update");
                     string partyName = Console.ReadLine()!;
                     System.Console.WriteLine("Enter the symbol of the party to update");
                     string symbol = Console.ReadLine()!;
                     Party party1  = new Party()
                     {
                        Name = partyName,
                        Symbol = symbol,
                     };
                     PartyRepository repository = new PartyRepository();
                     repository.Update(party1);
                     SuperAdmin();
                     break;
                    default:
                    System.Console.WriteLine("Please enter a valid input");
                    SuperAdmin();
                    break;
                }
                }
                else
                {
                    System.Console.WriteLine("Please begin a session");
                    SuperAdmin();
                }
                break;
                 case 3:
                 if (currentSession != null)
                 {
                    System.Console.WriteLine("Press 1 to Register position\nPress 2 to view position contestants\nPress 3 to update position");
                 int response4 = int.Parse(Console.ReadLine()!);
                 switch (response4)
                 {
                    case 1:
                    RegisterPosition();
                    SuperAdmin();
                    break;
                    case 2:
                    PositionRepository positionRepository = new PositionRepository();
                    System.Console.WriteLine("Enter the name of the position to view thier contestant");
                    string name = Console.ReadLine()!;
                   var contestants2 =  positionRepository.GetContestants(name);
                   foreach (var item in contestants2) 
                   {
                         System.Console.WriteLine($"{item.FullName} {item.Age} {item.Phonenumber} {item.UserEmail} {item.Count} {item.Party}");
                   }
                   SuperAdmin();
                   break;
                    default:
                    System.Console.WriteLine("Please enter a valid input");
                    SuperAdmin(); 
                    break;
                 }
                 }
                else
                {
                    System.Console.WriteLine("Please begin a session");
                    SuperAdmin();
                }
                break;
                case 4:
                if (currentSession != null)
                {
                    System.Console.WriteLine("Press 1 to start election\nPress 2 to end election");
                int response6 = int.Parse(Console.ReadLine()!);
                if (response6 == 1)
                {
                    System.Console.WriteLine("Enter the position to start the election");
                    string position = Console.ReadLine()!;
                    bool m = true;
                var voteSession = new VoteSession()
                {
                    Position = position,
                    TimeHeld = DateTime.Today,
                    IsActive = m,        
                };
                List<Contestant> contestants = new List<Contestant>();
                VoteRepository voteRepository1 = new VoteRepository();
                VotingService service = new VotingService();
                voteRepository1.Update(voteSession);
                
                foreach (var item in contestantRepository.GetAll())
                {
                    var id = voteRepository1.GetCurrentSession();
                    System.Console.WriteLine($"Press 1 to register\n {item.FirstName} {item.LastName} {item.Age} {item.Phonenumber} {item.UserEmail} {item.Count} {item.Party} {item.IsVoting = true }\n\nPress 2 to skip registration");
                    int response2 = int.Parse(Console.ReadLine()!);
                    switch (response2)
                    {
                        
                        case 1:
                       var contestant = new Contestant()
                       {
                            Age = item.Age,
                            Count = item.Count,
                            IsVoting = true,
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                            Party = item.Party,
                            Phonenumber = item.Phonenumber,
                            VotingTag = item.VotingTag,
                            Position = item.Position,
                            UserEmail = item.UserEmail,
                       };
                       contestantRepository.Update(contestant);
                       contestants.Add(contestant);
                        VoteRepository voteRepository = new VoteRepository();
                       VoteSession voteSession1 = new VoteSession()
                        {
                            Id = id.Id,
                            Position = position,
                            Contestants = contestants
                        };
                        voteRepository.Update(voteSession1);
                        break;
                        case 2:
                        continue;
                        default:
                        goto case 1;
                    }
                }
                        System.Console.WriteLine("Registeration complete");
                        SuperAdmin();
                }
                if (response6 == 2)
                {
                    VoteRepository voteRepository = new VoteRepository();
                    var session = voteRepository.GetCurrentSession();
                    
                        int count2 =0;
                    int count = 0;
                    var contestant = voteRepository.GetVoteResults();
                    foreach (var item in contestant)
                    {
                        count2++;
                        if (count2 == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            System.Console.WriteLine($" {item.NumberOfVotes} {item.Party} {item.Name}");
                            continue;
                        }
                        if (count2 == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            System.Console.WriteLine($" {item.NumberOfVotes} {item.Party} {item.Name}");
                            continue;
                        }
                        if (count2 == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            System.Console.WriteLine($" {item.NumberOfVotes} {item.Party} {item.Name}");
                            continue;
                        }
                            System.Console.WriteLine($" {item.NumberOfVotes} {item.Party} {item.Name}");
       
                    }
                    
                    foreach (var item in voteRepository.GetAllVoters())
                    {
                         var voter = new Voter()
                {
                    Age = item.Age,
                    FirstName = item.FirstName,
                    HasVoted = false,
                    LastName = item.LastName,
                    Password = item.Password,
                    Phonenumber = item.Phonenumber,
                    Role = item.Role,
                    UserEmail = item.UserEmail,
                    DateCreated = item.DateCreated,
                            
                };
                        VoterRepository voterRepository = new VoterRepository();
                        voterRepository.Update(voter);
                        count++;
            }
            foreach (var item in contestantRepository.GetAll())
                    {
                        
                    var contestant1 = new Contestant()
                {
                    Age = item.Age,
                    FirstName = item.FirstName,
                    IsVoting = item.IsVoting = false,
                    LastName = item.LastName,
                    Phonenumber = item.Phonenumber,
                    UserEmail = item.UserEmail,
                    DateCreated = item.DateCreated,
                            
                };
                        
                        contestantRepository.Update(contestant1);
            }
                    System.Console.WriteLine("Total voters: " + count );
                    
                    
                }
                

                }
                else
                {
                    System.Console.WriteLine("Please begin a session");
                    SuperAdmin();
                }
                 break;
                default:
                System.Console.WriteLine("Please enter a correct reponse");
                break;
            }
        }
        public static void RegisterContestant()
        {

            System.Console.WriteLine("Enter the FirstName of the contestant");
            string name = Console.ReadLine()!;
            System.Console.WriteLine("Enter the LastName of the contestant");
            string LastName = Console.ReadLine()!;
            System.Console.WriteLine("Enter the age of the contestant");
            int age = int.Parse(Console.ReadLine()!);
            System.Console.WriteLine("Enter phonenumber of the contestant");
             string phonenumber=Console.ReadLine()!;
            System.Console.WriteLine("Enter the email of the contestants");
            string userEmail = Console.ReadLine()!;
            System.Console.WriteLine("Enter the position of the contestant"); 
            string position = Console.ReadLine()!;
            System.Console.WriteLine("Enter the password of the contestant");;
            string password = Console.ReadLine()!;
            System.Console.WriteLine("Enter the party of the contestant");
            string party = Console.ReadLine()!;
            var model = new Dtos.CreateContestantRequestModel()
            {
                FirstName = name,
                LastName = LastName,
                Age = age,
                Party = party,
                Password = password,
                Phonenumber = phonenumber,
                Position = position,
                UserEmail = userEmail,
            };
             ContestantService contestantService = new ContestantService();
             contestantService.Create(model);      
        }
        public static void RegisterParty()
        {
            System.Console.WriteLine("Enter the name of the party");
            string partyName = Console.ReadLine()!;
            System.Console.WriteLine("Enter the logo of the party");
            string partyLogo = Console.ReadLine()!;
            var party = new CreatePartyRequestModel()
            {
                Name = partyName,
                Logo = partyLogo,
            };
            PartyService partyService = new PartyService();
            partyService.Create(party);
        }

        public static void RegisterPosition()
        {
            System.Console.WriteLine("Enter the name of the position to register");
            string name = Console.ReadLine()!;
            var position = new CreatePositionRequestModel()
            {
               Name = name,
            };
            PositionService positionService = new PositionService();
            positionService.Create(position);
        }
    }
}