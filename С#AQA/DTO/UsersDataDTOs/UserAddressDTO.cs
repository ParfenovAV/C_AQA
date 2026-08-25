using System.Text.Json.Serialization;

namespace C_AQA.DTO.UsersDataDTOs;

public record UserAddressDTO(
    [property: JsonPropertyName("street")]
    string Street,
    [property: JsonPropertyName("city")]
    string City,
    [property: JsonPropertyName("geo")]
    GeoDTO Geo
);
