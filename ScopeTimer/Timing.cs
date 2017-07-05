using System;
using System.Collections.Generic;

namespace ScopeTimer
{
    public class Timing
    {
        public Timing(string scopeName)
        {
            InnerScopes = new List<Timing>();
            ScopeName = scopeName;
        }

        public TimeSpan Elapsed { get; internal set; }

        public List<Timing> InnerScopes { get; }

        public string ScopeName { get; }
    }
}