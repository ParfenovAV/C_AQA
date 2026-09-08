using System;
using System.Collections.Generic;
using System.Text;

namespace C_AQA.DTO.BookStoreDTO
{
    public record UserCreateResponseDTO(
        string UserId,
        string UserName,
        List<BookDTO> Books
    );
}
