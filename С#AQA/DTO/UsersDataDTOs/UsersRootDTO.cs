using System.Text.Json.Serialization;

namespace C_AQA.DTO.UsersDataDTOs;

public record UsersRootDTO(
    [property: JsonPropertyName("data")]
    List<UserDTO> Data
);
