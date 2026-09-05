using System;
using System.Collections.Generic;
using System.Text;

namespace C_AQA.DTO.PetsDTO
{
    public record PaginationDTO(
        int Page,
        int Limit,
        int TotalItems,
        int TotalPages
    );
}