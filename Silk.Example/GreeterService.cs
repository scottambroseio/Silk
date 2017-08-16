using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Silk.Example
{
    public interface IGreeterService
    {
        string GetGreeting();
    }

    public class GreeterService : IGreeterService
    {
        public string GetGreeting()
        {
            return "Hello world from greeter service";
        }
    }
}
