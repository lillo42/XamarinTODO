using Newtonsoft.Json;
using System;

namespace Todo.DTO
{
    public abstract class DTOBase
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public DTOBase()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
