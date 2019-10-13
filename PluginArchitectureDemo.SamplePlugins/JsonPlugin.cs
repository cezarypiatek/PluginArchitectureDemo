using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Newtonsoft.Json;
using PluginArchitectureDemo.Contracts;

namespace PluginArchitectureDemo.SamplePlugins
{
    public class JsonPlugin : IPlugin
    {
        public string Name => nameof(JsonPlugin);

        public void ExecuteWithBclDependencies(IReadOnlyDictionary<string, string> input)
        {
            var textData = JsonConvert.SerializeObject(input);
            Console.WriteLine(textData);
        }

        public void ExecuteWithExternalDependencies(ImmutableArray<string> input)
        {
            var textData = JsonConvert.SerializeObject(input);
            Console.WriteLine(textData);
        }
    }
}
