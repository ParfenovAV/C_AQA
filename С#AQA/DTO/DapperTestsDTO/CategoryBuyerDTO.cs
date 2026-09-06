using System;
using System.Collections.Generic;
using System.Text;

namespace C_AQA.DTO.DapperTestsDTO
{
    public record CategoryBuyerDTO
        (
        long userId,

        string city,

        string firstName,

        string lastName,

        string productName
        );
}