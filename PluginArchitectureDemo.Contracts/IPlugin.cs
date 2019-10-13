using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace PluginArchitectureDemo.Contracts
{
    public interface IPlugin
    {
        string Name { get; }
        void ExecuteWithBclDependencies(IReadOnlyDictionary<string, string> input);
        void ExecuteWithExternalDependencies(ImmutableArray<string> input);
    }
}
