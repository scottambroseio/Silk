using System;

namespace Silk.Core.Attributes
{
    public class RouteAttribute : Attribute
    {
        public string Pattern { get; }

        public RouteAttribute(string pattern)
        {
            Pattern = pattern;
        }
    }
}
