using System;
using System.Collections.Generic;
using System.Text;

namespace C_AQA.DTO.BookStoreDTO
{
    public record DeleteBookRequestDTO(
        string Isbn,
        string UserId
        );
}
