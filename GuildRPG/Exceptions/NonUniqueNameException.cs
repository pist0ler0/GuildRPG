using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildRPG.Exceptions { 

    public class NonUniqueNameException : Exception
{
    public NonUniqueNameException() { }
    public NonUniqueNameException(string message) : base(message) { }
}
}
