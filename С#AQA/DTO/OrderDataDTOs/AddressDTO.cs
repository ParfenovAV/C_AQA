using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace C_AQA.DTO.OrderDataDTOs;
public record AddressDTO
(
    [property: JsonPropertyName("country")]
    string Country,
    [property: JsonPropertyName("city")]
    string City,
    [property: JsonPropertyName("street")]
    string Street,
    [property: JsonPropertyName("zip")]
    string Zip
);
