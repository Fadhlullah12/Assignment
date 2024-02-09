using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voting_App2.Models.Entities
{
    public class BaseEntities
    {
        public  string Id {get;set;} = Guid.NewGuid().ToString();
        public bool IsDeleted {get;set;} = false;
        public DateTime DateCreated {get;set;} = DateTime.Today;
    }
}