
namespace BlogSite.Models.Dtos.User.Requests;

public sealed record UpdateUserRequest(long Id,string FirstName, string LastName, string Email, string UserName, string Password);

