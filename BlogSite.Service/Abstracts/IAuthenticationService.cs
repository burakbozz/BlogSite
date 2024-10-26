using BlogSite.Models.Dtos.Token.Request;
using BlogSite.Models.Dtos.User.Requests;
using Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Abstracts
{
    public interface IAuthenticationService
    {
        Task<ReturnModel<TokenResponseDto>> LoginAsync(LoginRequestDto dto);
        Task<ReturnModel<TokenResponseDto>> RegisterAsync(RegisterRequestDto dto);
    }
}
