using System;

namespace Neas.Core
{
    /// <summary>
    /// Implementation of the <see cref="IModuleManager"/> interface.
    /// </summary>
    internal class ModuleManager : IModuleManager
    {
        /// <summary>
        /// All managed modules
        /// </summary>
        private readonly IModuleOrchastration[] _allModules;

        /// <summary>
        /// Create a new instance of the module manager for a set of modules.
        /// </summary>
        public ModuleManager(IModuleOrchastration[] allModules)
        {
            _allModules = allModules;
        }

        #region IModuleManager implementation

        public void Compose()
        {
            throw new NotImplementedException();
        }

        public void StartAll()
        {
            throw new NotImplementedException();
        }

        public void StopAll()
        {
            throw new NotImplementedException();
        }

        public void Start(IModule module)
        {
            throw new NotImplementedException();
        }

        public void Stop(IModule module)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<IModuleOrchastration> GetAll()
        {
            return _allModules;
        }
        #endregion
    }
}

