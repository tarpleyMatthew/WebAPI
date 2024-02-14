using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class JSONColor
    {
        [JsonPropertyName("color")]
        public string? Name { get; set; }

        [JsonPropertyName("value")]
        public string? HexCode { get; set; }
    }
}
