using System.Text.Json.Serialization;

namespace C_AQA.DTO;
public class CreateUserRequestDTO
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("job")]
    public string Job { get; set; }
}
