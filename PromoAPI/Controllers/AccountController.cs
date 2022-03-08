using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromoAPI.Model;
using PromoAPI.Repository.IRepository;

namespace PromoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepo _accountRepo;

        public AccountController(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody]SignUpModel signUpModel)
        {
            var result =await _accountRepo.SignUp(signUpModel);

            if (result.Succeeded){

                return Ok(result.Succeeded);
            }
            return Unauthorized();
          
        }
        [HttpPost("signin")]
        public async Task<IActionResult>signin([FromBody] SignInModel signInModel)
        {
            var result = await _accountRepo.SignIn(signInModel);

            if (string.IsNullOrEmpty(result))
            {

                return Unauthorized();
            }
            return Ok(result);

        }
    }
}
