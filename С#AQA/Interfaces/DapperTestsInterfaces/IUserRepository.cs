using System;
using System.Collections.Generic;
using System.Text;
using C_AQA.DTO.DapperTestsDTO;

namespace C_AQA.Interfaces.DapperTestsInterfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> GetUserByNameAndSurname(string firstName, string lastName);
    }
}
