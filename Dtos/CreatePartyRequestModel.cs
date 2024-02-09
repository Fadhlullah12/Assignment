using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace VOTING_APP2.Dtos
{
    public class CreatePartyRequestModel
    {
        public string Name {get; set; } = default!;
        public string Logo {get; set; } = default!;
    }
}