using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voting_App2.Models.Entities;
using VOTING_APP2.Dtos;

namespace VOTING_APP2.Implementations.Repositories
{
    public interface IPositionRepository
    {
        Position Create(Position position);
        List<Position> GetAll();
        List<ViewPositionContestants> GetContestants(string name);
        Position Update(Position position);
    }
}