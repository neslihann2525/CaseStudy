
using CaseStudy.Business.Result;
using CaseStudy.Dto.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Business.Abstract
{
    public interface IUsersManager
    {
        Task<IDataResult<SignUpResponseDto>> SignUp(SignUpRequestDto signUpRequest);
        Task<IResult> SignIn(SignInDto signInDto);
    }
}
