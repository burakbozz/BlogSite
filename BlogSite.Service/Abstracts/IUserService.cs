

using BlogSite.Models.Dtos.User.Requests;
using BlogSite.Models.Dtos.User.Responses;
using BlogSite.Models.Entities;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface IUserService
{

    Task<User> RegisterAsync(RegisterRequestDto dto);

    Task<User> GetByEmailAsync(string email);

    Task<User> LoginAsync(LoginRequestDto dto);

    Task<User> UpdateAsync(string id,UserUpdateRequestDto dto);

    Task<string> DeleteAsync(string id);

    Task<User> ChangePasswordAsync(string id, ChangePasswordRequestDto requestDto);
}
