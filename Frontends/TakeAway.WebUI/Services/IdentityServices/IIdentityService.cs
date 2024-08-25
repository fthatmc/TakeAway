using TakeAway.WebUI.Dtos.IdentityDtos;

namespace TakeAway.WebUI.Services.IdentityServices
{
    public interface IIdentityService
    {
        Task<bool> Signin(SigninDto signinDto);
    }
}
