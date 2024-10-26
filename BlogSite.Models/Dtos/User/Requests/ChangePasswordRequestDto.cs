

namespace BlogSite.Models.Dtos.User.Requests;

public sealed record ChangePasswordRequestDto(string CurrentPassword, string NewPassword, string NewPasswordAgain);

