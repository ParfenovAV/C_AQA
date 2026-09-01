using System;
using System.Collections.Generic;
using System.Text;

namespace C_AQA.DTO.DapperTestsDTO
{
    public record OrderItemsDTO
        (
        long id,

        long orderId,

        long productId,

        long quantity,

        double unitPrice
        );
}
