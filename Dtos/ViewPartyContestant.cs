using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VOTING_APP2.Dtos
{
    public class ViewPartyContestant
    {
        public string Position {get;set;} = default!;
        public string FullName{get; set;} = default!;
        public int Age{get; set;} = default!;
        public string Phonenumber{get; set;} = default!;
        public string UserEmail{get; set;} = default!;
        public int Count {get; set;} 
    }
}