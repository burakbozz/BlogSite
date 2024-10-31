﻿using BlogSite.Models.Dtos.Token.Request;
using BlogSite.Models.Dtos.User.Requests;
using BlogSite.Service.Abstracts;
using Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Concrets;

public class AuthenticationService(IUserService _userService, IJwtService _jwtService) : IAuthenticationService
{


    public async Task<ReturnModel<TokenResponseDto>> LoginAsync(LoginRequestDto dto)
    {
        var user = await _userService.LoginAsync(dto);
        var tokenResponse = await _jwtService.CreateJwtTokenAsync(user);

        return new ReturnModel<TokenResponseDto>
        {
            Data = tokenResponse,
            Message = "Giriş Başarılı",
            StatusCode = 200,
            Success = true
        };
    }

    public async Task<ReturnModel<TokenResponseDto>> RegisterAsync(RegisterRequestDto dto)
    {
        var user = await _userService.RegisterAsync(dto);
        var tokenResponse =await _jwtService.CreateJwtTokenAsync(user);

        return new ReturnModel<TokenResponseDto>
        {
            Data = tokenResponse,
            Message = "Kayıt işlemi Başarılı",
            StatusCode = 200,
            Success = true
        };
    }
}
