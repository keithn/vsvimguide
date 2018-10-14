using System;
using Microsoft.Extensions.Logging;

namespace VsVimGuide
{
    internal class App : IDisposable
    {
        private readonly ILogger _logger;

        public App(ILogger<App> logger)
        {
            _logger = logger;
        }

        public void Dispose() { }

        public void Run()
        {
            _logger.LogInformation("Running!");

        }
    }
}