using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Concretes;
using BlogSite.Models.Dtos.Category.Responses;
using BlogSite.Models.Dtos.Post.Responses;
using BlogSite.Models.Dtos.User.Requests;
using BlogSite.Models.Dtos.User.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using Core.Exceptions;
using Core.Responses;
using Microsoft.AspNetCore.Identity;

namespace BlogSite.Service.Concrets;

public sealed class UserService(UserManager<User> _userManager) : IUserService
{
    public async Task<User> ChangePasswordAsync(string id, ChangePasswordRequestDto requestDto)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı.");
        }
        if (requestDto.NewPassword.Equals(requestDto.NewPasswordAgain) is false)
        {
            throw new BusinessException("Parola Uyuşmuyor.");
        }

        var result = await _userManager.ChangePasswordAsync(user, requestDto.CurrentPassword, requestDto.NewPassword);

        if (result.Succeeded is false)
        {
            throw new BusinessException(result.Errors.ToList().First().Description);
        }

        return user;
    }

    public async Task<string> DeleteAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı.");
        }

        var result = await _userManager.DeleteAsync(user);

        if (result.Succeeded is false)
        {
            throw new BusinessException(result.Errors.ToList().First().Description);
        }

        return "Kullanıcı Silindi.";

    }

    public async Task<User> GetByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if(user is null)
        {
             Console.WriteLine("kullanıcı bulunamadı.");
        }
        return user;
    }

    public async Task<User> LoginAsync(LoginRequestDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);

        if (user is null)
        {
            throw new NotFoundException($"kullanıcı bulunamadı.");
        }

        bool checkPassword = await _userManager.CheckPasswordAsync(user, dto.Password);
        if (checkPassword is false)
        {
            throw new BusinessException("paralonız yanlış.");
        }

        return user;
    }

    public async Task<User> RegisterAsync(RegisterRequestDto dto)
    {
        User user = new User()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            City = dto.City,
            UserName = dto.UserName,

        };
        var result = await _userManager.CreateAsync(user, dto.Password);

        if(!result.Succeeded)
        {
            throw new BusinessException(result.Errors.ToList().First().Description);
        }

        return user;
    }

    public async Task<User> UpdateAsync(string id, UserUpdateRequestDto dto)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user is null)
        {
            throw new NotFoundException("kullanıcı bulunumadı.");            
        }
        user.UserName= dto.UserName;
        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.City = dto.City;

        var result = await _userManager.UpdateAsync(user);

        if(!result.Succeeded)
        {
            throw new BusinessException(result.Errors.ToList().First().Description);
        }
        return user;
        
    }
}
