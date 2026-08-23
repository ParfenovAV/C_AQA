using System.Text.Json.Serialization;

namespace C_AQA.DTO.UsersDataDTOs;

public record ProfileDTO(
    [property: JsonPropertyName("fullName")]
    string FullName,
    [property: JsonPropertyName("age")]
    int Age,
    [property: JsonPropertyName("address")]
    UserAddressDTO Address,
    [property: JsonPropertyName("tags")]
    List<string> Tags
);