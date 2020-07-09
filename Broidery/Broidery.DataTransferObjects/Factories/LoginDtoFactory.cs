using Broidery.DataTransferObjects.Dtos;

namespace Broidery.DataTransferObjects.Factories
{
    public class LoginDtoFactory
    {
        public ILoginResultDto CreateLoginResultDto(string token)
        {
            return new LoginResultDto(token);
        }
        private class LoginResultDto : ILoginResultDto
        {
            public string token { get; set; }            

            public LoginResultDto(string token)
            {
                this.token = token;
            }
        }
    }
}