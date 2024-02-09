using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voting_App2.Models.Entities;
using VOTING_APP2.Dtos;

namespace VOTING_APP2.Interfaces.Services
{
    public interface IContestantService
    {
        Contestant Create(CreateContestantRequestModel contestant);
       
    }
}