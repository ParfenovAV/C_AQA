using C_AQA.DTO.PetsDTO;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace C_AQA.Interfaces.Pets
{
    //[Headers("x-Tenant-ID: 550e8400-e29b-41d4-a716-446655440000")]
    public interface IPetAPI
    {
        [Get("/pets")]
        Task<DataOfAllPetsDTO> GetAllPetsAsync();
        
        [Get("/pets/{id}")]
        Task<PetDTO> GetPetByIdAsync(string id);
       
        [Get("/pets")]
        Task<DataOfAllPetsDTO> GetAllPetsFilteredByAgeMinAndLimitedAsync([Query] int ageMin, [Query] int limit);
    }
}
