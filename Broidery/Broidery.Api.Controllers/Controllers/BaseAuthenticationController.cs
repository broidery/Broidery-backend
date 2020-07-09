using System.ComponentModel.DataAnnotations;
using System;
using System.Threading.Tasks;
using Broidery.DataTransferObjects.Dtos;
using Broidery.Interactors;
using Microsoft.AspNetCore.Mvc;

namespace Broidery.Api.Controllers.Controllers
{
    public class BaseAuthenticationController : PlainController
    {
        private class UserLogin : IUserLogin
        {
            public string _email { get; }
            public string _password { get; }

            public UserLogin(string email, string password)
            {
                _email = email ?? throw new ArgumentNullException(nameof(email));
                _password = password ?? throw new ArgumentNullException(nameof(password));
            }
        }
        private readonly AuthenticationInteractor _authenticationInteractor;

        public BaseAuthenticationController(AuthenticationInteractor authenticationInteractor)
        {
            _authenticationInteractor = authenticationInteractor ?? throw new ArgumentNullException(nameof(authenticationInteractor));
        }
        [HttpPost("login")]
        public async Task<ActionResult<ILoginResultDto>> Login([FromBody] LoginRequestDto requestDto)
        {
            try
            {
                var validation = await _authenticationInteractor.Login(new UserLogin(requestDto.Email, requestDto.Password));
                return Ok(validation);

            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);                
            }
            catch(Exception e)
            {
                var result = new ObjectResult(e.Message);
                result.StatusCode = 401;
                return result;
            }
        }
    }
}