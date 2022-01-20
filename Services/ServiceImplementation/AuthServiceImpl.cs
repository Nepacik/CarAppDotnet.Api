using System;
using System.Net;
using CarAppDotNetApi.Dtos;
using CarAppDotNetApi.ErrorHandling;
using CarAppDotNetApi.Models;
using CarAppDotNetApi.Repositories;
using CarAppDotNetApi.Security;

namespace CarAppDotNetApi.Services.ServiceImplementation
{
    public class AuthServiceImpl: IAuthService
    {
        private readonly TokenCreator _tokenCreator;
        private readonly IUserRepository _userRepository;

        public AuthServiceImpl(IUserRepository userRepository, TokenCreator tokenCreator)
        {
            _userRepository = userRepository;
            _tokenCreator = tokenCreator;
        }
        
        public TokenDto AttemptToLogin(LoginDto loginDto)
        {
            var user = _userRepository.GetUserByUserName(loginDto.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                throw new AppException(HttpStatusCode.Unauthorized);
            }
            return new TokenDto
            {
                AccessToken = _tokenCreator.createToken(true, user),
                RefreshToken = _tokenCreator.createToken(false, user)
            };
        }

        public TokenDto AttemptRegister(RegisterDto registerDto)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
            User user = new User
            {
                Password = passwordHash,
                Username = registerDto.Username,
            };
            _userRepository.CreateUser(user);
            return new TokenDto
            {
                AccessToken = _tokenCreator.createToken(true, user),
                RefreshToken = _tokenCreator.createToken(false, user)
            };
        }

        public TokenDto RefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var username = _tokenCreator.ValidTokenAndGetUsername(refreshTokenDto.token);
            var user = _userRepository.GetUserByUserName(username);
            if (user == null)
            {
                throw new AppException(HttpStatusCode.Unauthorized, "Authorization fail");
            }

            return new TokenDto
            {
                AccessToken = _tokenCreator.createToken(true, user),
                RefreshToken = _tokenCreator.createToken(false, user)
            };
        }
    }
}