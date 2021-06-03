using System.Collections;

namespace d02_ex01.Configuration.Sources
{
    public interface IConfigurationSource
    {
        public Hashtable Param { get; set; }
        public int Priority { get; set; }
        public void createTable(string path);
    }
}