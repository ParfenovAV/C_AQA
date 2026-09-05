using System;
using System.Collections.Generic;
using System.Text;

namespace C_AQA.DTO.BookStoreDTO
{
    public record TokenUserResponseDTO(
 string Token,
 string Expires,
 string Status,
 string Result
    );
}
