using System;
using System.Collections.Generic;
using System.Text;

namespace C_AQA.DTO.DapperTestsDTO
{
    public record ReviewsDTO
        (
        long id,
        long userId,
        long productId,
        long rating,
        string comment,
        string createdAt
        );
}
