
using CaseStudy.Business.Abstract;
using CaseStudy.Business.Result;
using CaseStudy.Dto.AppUser;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersManager _userManager;
        public UserController(IUsersManager userManager)
        {
            _userManager = userManager;
        }
        [HttpPost("[action]")]
        public async Task<IDataResult<SignUpResponseDto>> SignUp(SignUpRequestDto signUpRequest)
        {
            var result = await _userManager.SignUp(signUpRequest);
            if (result.Success)
            {
                return result;
            }
            return new ErrorDataResult<SignUpResponseDto>(result.Message, result.Code);
        }

        [HttpPost("[action]")]
        public async Task<Business.Result.IResult> SignIn(SignInDto signInDto)
        {
            var result = await _userManager.SignIn(signInDto);
            if (result.Success)
            {
                return result;
            }
            return new ErrorResult(result.Message, result.Code);
        }
    }
}
