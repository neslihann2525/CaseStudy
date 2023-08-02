using AutoMapper;
using CaseStudy.Business.Abstract;
using CaseStudy.Business.Result;
using CaseStudy.Dto.AppUser;
using CaseStudy.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace CaseStudy.Business.Concrete
{
    public class UsersManager : IUsersManager
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        public UsersManager(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IDataResult<SignUpResponseDto>> SignUp(SignUpRequestDto signUpRequest)
        {
            if (signUpRequest == null)            
                return new ErrorDataResult<SignUpResponseDto>(new List<string> { "" }, "");
            
            var user = _mapper.Map<AppUser>(signUpRequest);
            var result = await _userManager.CreateAsync(user, signUpRequest.Password);
            if (result.Succeeded)
            {
                //tabloda role olmadığı için tek seferlik kontrol 
                //await _roleManager.CreateAsync(new AppRole { Name = "Member" });
                var roleResult = await _userManager.AddToRoleAsync(user, "Member");

                return new SuccessDataResult<SignUpResponseDto>(new SignUpResponseDto
                {
                    UserID = user.Id
                });
            }
            return new ErrorDataResult<SignUpResponseDto>(new List<string> { "" }, "");
        }

        public async Task<IResult> SignIn(SignInDto signInDto)
        {
            if (signInDto == null)            
                return new ErrorDataResult<SignInDto>(new List<string> { "" }, "");
            
            var result = await _signInManager.PasswordSignInAsync(signInDto.UserName, signInDto.Password, false, false);
            if (result.Succeeded)
                return new SuccessResult();

            return new ErrorDataResult<SignInDto>(new List<string> { "" }, "");
        }
    }
}
