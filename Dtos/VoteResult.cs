using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VOTING_APP2.Dtos
{
    public class VoteResult
    {
        public string Name { get;set; } = default!;
        public string Party {get;set; } = default!;
        public int NumberOfVotes { get;set; }
        public string Position { get;set; } = default!;
    }
}