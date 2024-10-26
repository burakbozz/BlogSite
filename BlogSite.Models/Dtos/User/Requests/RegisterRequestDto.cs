

namespace BlogSite.Models.Dtos.User.Requests;

public sealed record RegisterRequestDto(string FirstName,string LastName,string Email,string UserName,string Password,string City);

