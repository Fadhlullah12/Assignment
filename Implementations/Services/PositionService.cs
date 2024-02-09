using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voting_App2.Models.Entities;
using VOTING_APP2.Dtos;
using VOTING_APP2.Implementation.Repositories;
using VOTING_APP2.Interfaces.Services;
using VOTING_APP2.ontext;

namespace VOTING_APP2.Implementations.Services
{
    public class PositionService : IPositionService
    {
        PositionRepository positionRepository = new PositionRepository();
        VoteContext context = new VoteContext();
        public Position Create(CreatePositionRequestModel model)
        {
            var existingPosition = context.Positions.FirstOrDefault(x => x.PositionName == model.Name);
            if (existingPosition != null)
            {
                System.Console.WriteLine("Sorry position {0} already exists", existingPosition.PositionName);
                 throw new DuplicateItemException();
            }
            var position = new Position(){
                 PositionName = model.Name,
            };
            positionRepository.Create(position);
            System.Console.WriteLine("Position {0} created sucessfully", position.PositionName);
            return position;
        }
    }
}