using System;
using System.Diagnostics;

namespace ScopeTimer
{
    public class Scope : IDisposable
    {
        private readonly Timing _timing;

        private readonly Stopwatch _sw;

        public Scope(string scopeName)
        {
            _timing = new Timing(scopeName);
            _sw = new Stopwatch();
            _sw.Start();
        }

        public Timing Timing
        {
            get
            {
                _timing.Elapsed = _sw.Elapsed;
                return _timing;
            }
        }

        public void Dispose()
        {
            _sw.Stop();
            _timing.Elapsed = _sw.Elapsed;
        }

        public Scope Inner(string scopeName)
        {
            var timingBuilder = new Scope(scopeName);
            _timing.InnerScopes.Add(timingBuilder._timing);
            return timingBuilder;
        }
    }
}