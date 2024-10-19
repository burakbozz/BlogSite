

using BlogSite.Models.Dtos.User.Requests;
using BlogSite.Models.Dtos.User.Responses;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface IUserService
{
    ReturnModel<List<UserResponseDto>> GetAll();

    ReturnModel<UserResponseDto?> GetById(long id);

    ReturnModel<UserResponseDto> Add(CreateUserRequest create);

    ReturnModel<UserResponseDto> Update(UpdateUserRequest updateUser);

    ReturnModel<UserResponseDto> Remove(long id);
}
