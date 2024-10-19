using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Concretes;
using BlogSite.Models.Dtos.Category.Responses;
using BlogSite.Models.Dtos.Post.Responses;
using BlogSite.Models.Dtos.User.Requests;
using BlogSite.Models.Dtos.User.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using Core.Responses;

namespace BlogSite.Service.Concrets;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository,IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public ReturnModel<UserResponseDto> Add(CreateUserRequest create)
    {
        User createdUser = _mapper.Map<User>(create);
        

        _userRepository.Add(createdUser);

        UserResponseDto response = _mapper.Map<UserResponseDto>(createdUser);

        return new ReturnModel<UserResponseDto>
        {
            Data = response,
            Message = "User Eklendi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<UserResponseDto>> GetAll()
    {
        List<User> users = _userRepository.GetAll();
        List<UserResponseDto> userResponses = _mapper.Map<List<UserResponseDto>>(users);

        return new ReturnModel<List<UserResponseDto>>
        {
            Data = userResponses,
            Message = "User listelendi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<UserResponseDto?> GetById(long id)
    {
        User? user = _userRepository.GetById(id);
        UserResponseDto responseDto = _mapper.Map<UserResponseDto>(user);
        if (user is null)
        {
            return new ReturnModel<UserResponseDto?>
            {
                Data = null,
                Message = "",
                StatusCode = 404,
                Success = false
            };

        }
        return new ReturnModel<UserResponseDto?>
        {
            Data = responseDto,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<UserResponseDto> Remove(long id)
    {
        User user = _userRepository.GetById(id);
        User deletedUser = _userRepository.Remove(user);

        UserResponseDto response = _mapper.Map<UserResponseDto>(deletedUser);

        return new ReturnModel<UserResponseDto>
        {
            Data = response,
            Message = "User Silindi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<UserResponseDto> Update(UpdateUserRequest updateUser)
    {
        User? user = _userRepository.GetById(updateUser.Id);
        user.FirstName = updateUser.FirstName;
        user.LastName = updateUser.LastName;
        user.Email = updateUser.Email;
        user.UpdatedDate = DateTime.Now;
        

        User updatedUser = _userRepository.Update(user);


        UserResponseDto dto = _mapper.Map<UserResponseDto>(updatedUser);
        return new ReturnModel<UserResponseDto>
        {
            Data = dto,
            Message = "User güncellendi",
            StatusCode = 200,
            Success = true
        };
    }
}
