using System;
using System.Collections.Generic;

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
        /// Dependency graph that uses the same array index as <see cref="_allModules"/>
        /// </summary>
        private readonly ModuleDependencyLink[] _dependencyGraph;

        /// <summary>
        /// Create a new instance of the module manager for a set of modules.
        /// </summary>
        public ModuleManager(IModuleOrchastration[] allModules)
        {
            _allModules = allModules;
            _dependencyGraph = new ModuleDependencyLink[allModules.Length];
        }

        #region IModuleManager implementation

        public void Compose()
        {
            var moduleCount = _allModules.Length;
            var nameMap = new Dictionary<string, int>();
            var dependents = new Dictionary<int, List<int>>();

            // Step 1: Assign index to each module and create name lookup
            // Prepare link object for the next iteration and the dependent collector
            for (int index = 0; index < moduleCount; index++)
            {
                var module = _allModules[index];
                module.ModuleIndex = index;

                _dependencyGraph[index] = new ModuleDependencyLink(index);

                nameMap[module.Name] = index;
                dependents[index] = new List<int>();
            }

            // Step 2: Iterate all modules again and link all dependencies
            for (int index = 0; index < moduleCount; index++)
            {
                var module = _allModules[index];
                var dependencies = module.GetDependencies();
                var resolvedDependencies = new ResolvedDependency[dependencies.Length];

                // Iterate all dependencies and create cross links
                var dependencyLinks = new int[dependencies.Length];
                for (int i = 0; i < dependencies.Length; i++)
                {
                    // Fetch dependency and its index
                    var dependency = dependencies[i];
                    var dependencyIndex = nameMap[dependency.Name];

                    // Link dependency and dependent
                    dependencyLinks[i] = dependencyIndex;
                    dependents[dependencyIndex].Add(index);

                    // Resolve the dependency
                    var resolved = dependency.Resolve(_allModules[dependencyIndex]);
                    resolvedDependencies[i] = resolved;
                }
                _dependencyGraph[index].Dependencies = dependencyLinks;

                module.ResolveDependencies(resolvedDependencies);
            }

            // Step 3: Iterate over the dependents dictionary and create the reference array
            foreach (var pair in dependents)
            {
                var references = pair.Value.ToArray();
                _dependencyGraph[pair.Key].Dependents = references;
            }
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

        /// <summary>
        /// Class that represents a module as well as its dependents and dependencies.
        /// </summary>
        private class ModuleDependencyLink
        {
            /// <summary>
            /// Create a temporary reference to another module
            /// </summary>
            public ModuleDependencyLink(int index)
            {
                ModuleIndex = index;
            }

            /// <summary>
            /// Internal numeric module index to reduce string handling
            /// </summary>
            public int ModuleIndex { get; private set; }

            /// <summary>
            /// Module indexes of the dependents
            /// </summary>
            public int[] Dependents { get; set; }

            /// <summary>
            /// Module index of the dependencies
            /// </summary>
            public int[] Dependencies { get; set; }
        }
    }
}

