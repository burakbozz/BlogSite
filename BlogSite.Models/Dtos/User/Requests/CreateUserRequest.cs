

namespace BlogSite.Models.Dtos.User.Requests;

public sealed record CreateUserRequest(string FirstName,string LastName,string Email,string UserName,string Password);

