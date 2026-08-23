using System.Text.Json.Serialization;

namespace C_AQA.DTO.UsersDataDTOs;

public record GeoDTO(
    [property: JsonPropertyName("lat")]
    double Lat,
    [property: JsonPropertyName("lng")]
    double Lng
);
