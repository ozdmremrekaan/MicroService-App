using Mango.Services.AuthAPI.Models.Dto;
using Mango.Services.AuthAPI.RabbitMQMessageSender;
using Mango.Services.AuthAPI.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDto _response;
        private readonly IRabbitMQAuthMessageSender _messageSender;
        private readonly IConfiguration _configuration;
        public AuthController(IAuthService authService, IConfiguration configuration,IRabbitMQAuthMessageSender messageSender)
        {
            _authService = authService;
            _response = new();
            _configuration = configuration;
            _messageSender = messageSender;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {
            var errorMessage = await _authService.Register(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.isSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            _messageSender.SendMessage(model.Email, _configuration.GetValue<string>("TopicAndQueueNames:RegisterUserQueue"));
            return Ok(_response);
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            var assignRoleSuccessfull = await _authService.AssignRole(model.Email, model.Role.ToUpper());
            if (!assignRoleSuccessfull)
            {
                _response.isSuccess = false;
                _response.Message = "Error encountered ! ";
                return BadRequest(_response);
            }
            
            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);
            if(loginResponse.User == null)
            {
                _response.isSuccess=false;
                _response.Message = "UserName or Password could not be found ! ";
                return BadRequest(_response);
            }
            _response.Result = loginResponse;
            return Ok(_response);
        }
    }
}
