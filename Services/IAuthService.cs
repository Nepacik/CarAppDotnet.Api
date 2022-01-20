using CarAppDotNetApi.Dtos;

namespace CarAppDotNetApi.Services
{
    public interface IAuthService
    {
        public TokenDto AttemptToLogin(LoginDto loginDto);
        public TokenDto AttemptRegister(RegisterDto registerDto);

        public TokenDto RefreshToken(RefreshTokenDto refreshTokenDto);
    }
}