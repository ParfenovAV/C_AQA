using System;
using System.Collections.Generic;
using System.Text;

namespace C_AQA.DTO.DapperTestsDTO
{
    public record OrderItemDetailsDTO
        (
        long orderId,

        string productName,

        long quantity,

        double unitPrice
        );
}
