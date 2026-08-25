using System.Text.Json.Serialization;

namespace C_AQA.DTO.FirstTestDTO;

public class UserResponseDTO
{
    [JsonPropertyName("data")]
    public UserDataDTO Data { get; set; }
}
