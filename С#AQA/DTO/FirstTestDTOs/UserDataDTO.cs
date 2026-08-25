using System.Text.Json.Serialization;

namespace C_AQA.DTO.FirstTestDTO;

public class UserDataDTO
{
    [JsonPropertyName("id")]
    public int ID { get; set; }
   
    [JsonPropertyName("email")]
    public string Email { get; set; }
    
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }
    
    [JsonPropertyName("last_name")]
    public string LastName { get; set; }
}
