using System;
using System.Collections.Generic;

namespace Neas.Core
{
    public class Kernel : IKernel
    {
        private IConfigManager _configManager = new ConfigManager("./config");
        public IConfigManager ConfigManager
        {
            get { return _configManager; }
        }
        
        public IEnumerable<IModule> ResolveModules()
        {
            return new IModule[0];
        }
    }
}