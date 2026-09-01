using System;
using System.Collections.Generic;
using System.Text;
using C_AQA.DTO.DapperTestsDTO;

namespace C_AQA.Interfaces.DapperTestsInterfaces
{
    public interface IAddressRepository
    {
        Task<AddressDTO> GetAddressByUserId(int userId);
    }
}
