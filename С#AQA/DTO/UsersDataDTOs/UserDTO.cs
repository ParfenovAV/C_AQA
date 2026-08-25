using System.Text.Json.Serialization;

namespace C_AQA.DTO.UsersDataDTOs;

public record UserDTO(
    [property: JsonPropertyName("id")]
    int Id,
    [property: JsonPropertyName("username")]
    string Username,
    [property: JsonPropertyName("profile")]
    ProfileDTO Profile,
    [property: JsonPropertyName("roles")]
    List<string> Roles
);
