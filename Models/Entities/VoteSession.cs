using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voting_App2.Models.Entities;

namespace VOTING_APP2.Models.Entities
{
    public class VoteSession : BaseEntities
    {
        public string Position {get; set;} = default!;
        public List<Contestant> Contestants { get; set; } = default!;
        public DateTime TimeHeld { get; set;} = DateTime.Today;
        public List<Voter> Voters {get; set;} = default!;
        public bool IsActive { get;set;} = true;

    }
}