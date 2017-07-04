using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ScopeTimer
{
    public class ScopeTimer
    {
        public ScopeTimer(string scopeName)
        {
            InnerScopes = new List<ScopeTimer>();
            ScopeName = scopeName;
        }

        public TimeSpan Elapsed { get; private set; }

        public List<ScopeTimer> InnerScopes { get; }

        public string ScopeName { get; }

        public class Scope : IDisposable
        {
            private readonly ScopeTimer _scopeTimer;

            private readonly Stopwatch _sw;

            public Scope(string scopeName)
            {
                _scopeTimer = new ScopeTimer(scopeName);
                _sw = new Stopwatch();
                _sw.Start();
            }

            public ScopeTimer ScopeTimer
            {
                get
                {
                    _scopeTimer.Elapsed = _sw.Elapsed;
                    return _scopeTimer;
                }
            }

            public void Dispose()
            {
                _sw.Stop();
                _scopeTimer.Elapsed = _sw.Elapsed;
            }

            public Scope Inner(string scopeName)
            {
                var scopeTimerBuilder = new Scope(scopeName);
                _scopeTimer.InnerScopes.Add(scopeTimerBuilder._scopeTimer);
                return scopeTimerBuilder;
            }
        }
    }
}