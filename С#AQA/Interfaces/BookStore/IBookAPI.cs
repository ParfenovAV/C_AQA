using C_AQA.DTO.BookStoreDTO;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace C_AQA.Interfaces.BookStore
{
    public interface IBookAPI
    {
        [Post("/Account/v1/User")]
        Task<UserResponseDTO> CreateUserAsync([Body] UserCreateBodyDTO credentials);
        [Post("/Account/v1/GenerateToken")]
        Task<TokenUserResponseDTO> GetUserTokenAsync([Body] UserCreateBodyDTO credentials);
    }
}