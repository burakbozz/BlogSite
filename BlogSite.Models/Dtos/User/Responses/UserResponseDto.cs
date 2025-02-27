﻿
namespace BlogSite.Models.Dtos.User.Responses;

public sealed record UserResponseDto
{
    public long Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public string Email { get; init; }
    public string Username { get; init; }
    public string Password { get; init; }
    public DateTime CreatedDate { get; init; }
    public DateTime UpdatedDate { get; init; }
}
