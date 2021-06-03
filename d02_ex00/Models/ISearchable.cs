using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace d02_ex00.Models
{
    public interface ISearchable
    {
        public string Title {get; set; }
        public string TypeMedia { get; set; }
    }
}