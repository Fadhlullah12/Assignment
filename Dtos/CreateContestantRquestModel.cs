using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace VOTING_APP2.Dtos
{
    public class CreateContestantRequestModel
    {
        public string FirstName{get;set;} = default!;
        public string LastName{get;set;} = default!;
        public int Age{get;set;} = default!;
        public string Phonenumber{get;set;} = default!;
        public string UserEmail{get;set;} = default!;
        public string Position{get;set;} = default!;
        public string Party {get; set;} = default!;
        public string Password {get; set;} = default!;
    }
}