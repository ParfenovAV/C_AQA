using System;
using System.Collections.Generic;
using System.Text;

namespace C_AQA.DTO.DapperTestsDTO
{
    public record OrderDTO
         (
         int id,

         string userId,

         string orderDate,

         int status,

         int totalPrice
         );
}
