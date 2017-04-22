using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;

namespace Todo.DTO
{
    public class Todo : DTOBase
    {
        [JsonProperty(PropertyName = "text")]
        public string Nome { get; set; }
        [JsonProperty(PropertyName = "complete")]
        public bool Done { get; set; }
        [Version]
        public string Version { get; set; }
    }
}
