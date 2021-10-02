using Core.DataServices.Abstracts;
using Entities.Dto;
using Entities.Dto.Utilities;

namespace Business.DataServices.Abstracts
{
    public interface IUserService :  IDataService<UserDto>
    {
        UserDto Login(LoginRequest loginDto);
        UserDto Register(UserDto userDto);
        string ForgetPassword(string email);
        bool CanRestart (string code);
        string RestartPassword(LoginRequest loginDto);
        
    }
}
