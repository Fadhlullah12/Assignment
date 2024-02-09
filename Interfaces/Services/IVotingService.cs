using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VOTING_APP2.Dtos;
using VOTING_APP2.Models.Entities;

namespace VOTING_APP2.Interfaces.Services
{
    public interface IVotingService
    {
        VoteSession Create(StartVotingRequestModel session);
    }
}