using System;
using System.Collections;
using System.IO;
using System.Text.Json;

namespace d02_ex01.Configuration.Sources
{
    public class JsonSource : IConfigurationSource
    {
        public Hashtable Param { get; set; }
        public string JsonString { get; set; }
        public int Priority { get; set; }

        public JsonSource(int priority)
        {
            Priority = priority;
        }

        public void createTable(string path)
        {
            try
            {
                JsonString = File.ReadAllText(path);
                Param = JsonSerializer.Deserialize<Hashtable>(JsonString);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid data. Check your input and try again.");
                Environment.Exit(1);
            }
            JsonString = File.ReadAllText(path);
            Param = JsonSerializer.Deserialize<Hashtable>(JsonString);
        }
    }
}