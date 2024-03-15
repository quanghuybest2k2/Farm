using System.Text.Json.Serialization;

namespace farm_api.Models.Common
{
    public class BaseDTO
    {
        [JsonPropertyOrder(-9)]
        public Guid Id { get; set; }
    }
}
