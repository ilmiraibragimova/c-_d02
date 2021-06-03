using System;
using System.Collections;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace d02_ex01.Configuration.Sources
{
    public class YamlSource: IConfigurationSource
    {
        public Hashtable Param { get; set; }
        public string YamlString { get; set; }
        public int Priority { get; set; }

        public YamlSource(int priority)
        {
            Priority = priority;
        }

        public void createTable(string path)
        {
            try
            {
                YamlString = File.ReadAllText(path);
                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(new CamelCaseNamingConvention())
                    .Build();
                Param = deserializer.Deserialize<Hashtable>(YamlString);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid data. Check your input and try again.");
                Environment.Exit(1);
            }
        }
    }
}
  