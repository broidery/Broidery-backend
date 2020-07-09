using System;
using System.Threading.Tasks;
using Broidery.DataAccess;
using Broidery.DataTransferObjects.Dtos;
using Broidery.DataTransferObjects.Factories;

namespace Broidery.Interactors
{
    public partial class AuthenticationInteractor
    {
        public class LoginRequest : ILoginRequest
        {
            public string _email { get; }
            public string _password { get; }

            public LoginRequest(string email, string password)
            {
                _email = email ?? throw new ArgumentNullException(nameof(email));
                _password = password ?? throw new ArgumentNullException(nameof(password));
            }
        }
        private class AuthorizationDto : IToken
        {
            public string _token { get; }

            public AuthorizationDto(string token)
            {
                _token = token ?? throw new ArgumentNullException(nameof(token));
            }
        }

        private readonly IUserRepository _userRepository;
        private readonly LoginDtoFactory _loginDtofactory;
        private readonly Random random = new Random();

        public AuthenticationInteractor(IUserRepository userRepository, LoginDtoFactory loginDtofactory)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _loginDtofactory = loginDtofactory ?? throw new ArgumentNullException(nameof(loginDtofactory));
        }
        public async Task<ILoginResultDto> Login(IUserLogin login)
        {
            if (login is null)
            {
                throw new ValidationException("El objeto login es nulo");
            }
            else
            {
                if (string.IsNullOrEmpty(login._email))
                {
                    throw new ValidationException("El email ingresado es nulo o esta bacío");
                }
                else if (string.IsNullOrEmpty(login._password))
                {
                    throw new ValidationException("El password ingresado es nulo o esta bacío");
                }
            }
            var entity = await _userRepository.GetByEmail(login._email.ToLower(), login._password);

            if (entity is null)
            {
                throw new ValidationException("El email o el password ingresado es incorrecto");
            }
            if (string.IsNullOrEmpty(entity.Token))
            {
                var token = await ValidateKey();
                await _userRepository.SaveToken(login._email, token);
                return new LoginDtoFactory().CreateLoginResultDto(token);
            }
            else
            {
                return new LoginDtoFactory().CreateLoginResultDto(entity.Token);
            }
        }
        private async Task<string> ValidateKey()
        {
            var token = BuildKey();
            var validateKey = await _userRepository.Exist(token);
            if (validateKey)
            {
                return await ValidateKey();
            }
            return token;
        }
        private string BuildKey()
        {
            var keyBuilder = string.Empty;
            var basket = new char[6];
            for (int i = 0; i < 6; i++)
            {
                var code = random.Next(25);
                basket[i] = (char)(random.Next(2) == 0 ? code + 65 : code + 97);
            }
            return keyBuilder + DateTime.UtcNow.Ticks + "-" + new string(basket);
        }

    }
}
