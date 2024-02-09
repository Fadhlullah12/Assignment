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
    public class PartyService : IPartyService
    {
        PartyRepository partyRepository = new PartyRepository();
        VoteContext context = new VoteContext();
        public Party Create(CreatePartyRequestModel model)
        {
            var existing = context.Parties.FirstOrDefault(p => p.Name == model.Name);
            if (existing != null)
            {
                 System.Console.WriteLine("Sorry party already exists");
            }
            var party = new Party(){
                Name = model.Name,
                Symbol = model.Logo,
            };
            partyRepository.Create(party);
            System.Console.WriteLine("Party created successfully");
            return party;
        }

    }
}