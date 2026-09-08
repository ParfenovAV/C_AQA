using System;
using System.Collections.Generic;
using System.Text;

namespace C_AQA.DTO.DapperTestsDTO
{
    public record AddressDTO
        (
        long id,
        long userId,
        string city,
        string street,
        string house,
        string apartment
        );
}
