using C_AQA.DTO.DapperTestsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace C_AQA.Interfaces.DapperTestsInterfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
    }
}
