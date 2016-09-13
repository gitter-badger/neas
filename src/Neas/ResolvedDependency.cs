using System;

namespace Neas
{
    /// <summary>
    /// Structure that represents a resolved dependency
    /// </summary>
    public class ResolvedDependency
    {
        /// <summary>
        /// Create a resolved dependency from a <see cref="DeclaredDependency"/> and the 
        /// referenced <see cref="IModule"/>
        /// </summary>
        public ResolvedDependency(DeclaredDependency declared, IModule resolvedReference)
        {
            Name = declared.Name;
            Module = resolvedReference;
        }

        /// <summary>
        /// Name of the module
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Resolved refrence to the other module
        /// </summary>
        /// <value>The module.</value>
        public IModule Module
        {
            get;
            private set;
        }
    }
}

