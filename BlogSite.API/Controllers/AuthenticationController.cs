﻿using BlogSite.Models.Dtos.User.Requests;
using BlogSite.Service.Abstracts;
using Core.Tokens.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController(IAuthenticationService _authenticationService, DecoderService decoderService) : CustomBaseController(decoderService)
{

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
    {
        var result = await _authenticationService.LoginAsync(dto);
        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
    {
        var result = await _authenticationService.RegisterAsync(dto);
        return Ok(result);
    }
}