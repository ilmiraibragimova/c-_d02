using System;
using System.Collections;
using System.Collections.Generic;
using d02_ex01.Configuration.Sources;
using YamlDotNet.Core.Tokens;

namespace d02_ex01.Configuration
{
    public class Configuration
    {
        public Hashtable Params { get; set; }
        public Hashtable ParamSource { get; set; }

        public Configuration(Hashtable paramSource)
        {
            ParamSource = paramSource;
        }

        public void mergeTable(Hashtable source1)
        {
           
           foreach (DictionaryEntry item in source1)
               if (!ParamSource.ContainsKey(item.Key))
                    ParamSource.Add(item.Key, item.Value);
        }
        
    }
}