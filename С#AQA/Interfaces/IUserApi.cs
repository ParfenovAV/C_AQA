using Refit;
using C_AQA.DTO.FirstTestDTO;

namespace C_AQA.Interfaces
{
    [Headers("x-api-key: free_user_3HwJzQXJkOKmToPVkagXbkD2ywW")]
    public interface IUserApi
    {
        [Get("/users/{id}")]
        Task<UserResponseDTO> GetUserAsync(int id);

        [Post("/users")]
        Task<CreateUserResponseDTO> CreateUserAsync([Body] CreateUserRequestDTO request);

        [Delete("/users/{id}")]
        Task<ApiResponse<string>> DeleteUserAsync(int id);
    }
}
