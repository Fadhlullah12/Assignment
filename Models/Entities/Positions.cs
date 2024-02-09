using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voting_App2.Models.Entities
{
    public class Position : BaseEntities    
    {
       public string PositionName{get;set;} = default!;
    }
}