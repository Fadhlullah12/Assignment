using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voting_App2.Models.Entities
{
    public class Contestant : BaseEntities
    {
        public string FirstName{get;set;} = default!;
        public string LastName{get;set;} = default!;
        public int Age{get;set;} = default!;
        public string Phonenumber{get;set;} = default!;
        public string UserEmail{get;set;} = default!;
        public string Party{get;set;} = default!;
        public int Count{get;set;}
        public string Position{get;set;} = default!;
        public string VotingTag{get; set;} = default!;
        public bool IsVoting{get; set;}
        public string VoteSessionId{get; set;} = default!;
    }
}