

namespace Voting_App2.Models.Entities
{
    public class Voter : BaseEntities
    {
        public string FirstName{get;set;} = default!;
        public string LastName{get;set;} = default!;
        public int Age{get;set;} = default!;
        public string Phonenumber{get;set;} = default!;
        public  string Role{get;set;} = default!;
        public string UserEmail{get;set;} = default!;
        public string Password{get;set;} = default!;
        public bool HasVoted{get;set;}
        public string VoteSessionId{get;set;} = default!;
    }
}