using System;
using System.Collections.Generic;

namespace ScopeTimer
{
    public class ScopeTimer
    {
        public ScopeTimer(string scopeName)
        {
            InnerScopes = new List<ScopeTimer>();
            ScopeName = scopeName;
        }

        public TimeSpan Elapsed { get; internal set; }

        public List<ScopeTimer> InnerScopes { get; }

        public string ScopeName { get; }
    }
}