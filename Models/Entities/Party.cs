using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voting_App2.Models.Entities
{
    public class Party : BaseEntities
    {
        public string Name{get;set;} = default!;
        public string Symbol {get; set;} = default!;
    }
}