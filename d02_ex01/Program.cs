using System;
using System.Collections;
using d02_ex01.Configuration.Sources;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace d02_ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 4 || !Int32.TryParse(args[1], out int a) || !Int32.TryParse(args[3], out a))
            {
                Console.WriteLine("Invalid data. Check your input and try again.");
                return;
            }
            IConfigurationSource jsonSource = new JsonSource(Int32.Parse(args[1]));
            jsonSource.createTable(args[0]);
            IConfigurationSource yamlSource = new YamlSource(Int32.Parse(args[3]));
            yamlSource.createTable(args[2]);
            Hashtable temp = new Hashtable();
            if (jsonSource.Priority > yamlSource.Priority)
                temp = jsonSource.Param;
            else
            {
                temp = yamlSource.Param;
            }
            Configuration.Configuration configuration = new Configuration.Configuration(temp);
            
            if (temp == yamlSource.Param)
                temp = jsonSource.Param;
            else
            {
                temp = yamlSource.Param;
            }
            configuration.mergeTable(temp);
            foreach (DictionaryEntry di in configuration.ParamSource) 
            {
                Console.WriteLine("{0} : {1}", di.Key, di.Value);
            }
        }
    }
}
