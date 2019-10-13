using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using PluginArchitectureDemo.Contracts;

namespace PluginArchitectureDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var pluginPath = Path.GetFullPath(args[0]);
            var pluginLoader = new PluginLoadContext(pluginPath);
            var assembly =  pluginLoader.LoadFromAssemblyPath(pluginPath);
            var plugins =  assembly.GetTypes().Where(t => typeof(IPlugin).IsAssignableFrom(t)).ToList();
            var sampleData = new Dictionary<string, string>
            {
                ["key1"] = "value1",
                ["key2"] = "value2",
            };

            var sampleExternalData = new List<string>()
            {
                "A",
                "B",
                "C"
            }.ToImmutableArray();

            foreach (var plugin in plugins)
            {
                var pluginInstance = (IPlugin) Activator.CreateInstance(plugin);
                Console.WriteLine($"Execute plugin {pluginInstance.Name}");
                pluginInstance.ExecuteWithBclDependencies(sampleData);
                pluginInstance.ExecuteWithExternalDependencies(sampleExternalData);
            }
        }
    }
}
