using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace UnityBacnet.POC.Infrastructure.Config
{
    public class MappingConfigLoader
    {
        public Dictionary<string, string> Load(string path)
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Dictionary<string, string>>(json);
        }
    }
}
