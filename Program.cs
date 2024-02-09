// See https://aka.ms/new-console-template for more information
using VOTING_APP2.Implementation.Repositories;
using VOTING_APP2.Menu;
VoteRepository voteRepository = new VoteRepository();
foreach (var item in voteRepository.GetVoteResults())
{
    System.Console.WriteLine($"{item.Name} {item.Party} {item.NumberOfVotes} {item.Position}");
}
PartyRepository partyRepository = new PartyRepository();
foreach (var item in partyRepository.GetContestants("APC"))
{
    System.Console.WriteLine($"{item.FullName} {item.UserEmail} {item.Phonenumber} {item.Age} {item.Count} {item.Position}");
}


//    if (a == false)
//    {
//       System.Console.WriteLine($"{item.LastName} {a}");

//    }
// VotersMenu votersMenu = new VotersMenu();
// votersMenu.VoterMunu("Votes");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Hello, World!");
MainMenu .Main();