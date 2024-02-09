using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voting_App2.Models.Entities;

namespace VOTING_APP2.Models.Entities
{
    public class User : BaseEntities
    {
        public  string Role{get;set;} = default!;
        public string UserEmail{get;set;} = default!;
        public string Password{get;set;} = default!;
    }
}