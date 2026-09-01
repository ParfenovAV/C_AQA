using System;
using System.Collections.Generic;
using System.Text;

namespace C_AQA.DTO.DapperTestsDTO
{
    public record OrderDTO
         (
         long id,

         long userId,

         string orderDate,

         string status,

         double totalPrice
         );
}
