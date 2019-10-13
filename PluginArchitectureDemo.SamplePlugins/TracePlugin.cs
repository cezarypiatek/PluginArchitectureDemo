using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using PluginArchitectureDemo.Contracts;

namespace PluginArchitectureDemo.SamplePlugins
{
    public class TracePlugin:IPlugin
    {
        public string Name => nameof(TracePlugin);

        public void ExecuteWithBclDependencies(IReadOnlyDictionary<string, string> input)
        {
            foreach (var keyValue in input)
            {
                Console.WriteLine($"{keyValue.Key}={keyValue.Value}");
            }
        }

        public void ExecuteWithExternalDependencies(ImmutableArray<string> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}