using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VOTING_APP2
{
    public class DuplicateItemException : Exception
    {
        public override string Message 
       {
        get 
        {
          return "Sorry some of the credentials already exists";
        }
       }
       public override string HelpLink
       {
        get
        {
          return "Check your credentials";
        }
       }
    }
}