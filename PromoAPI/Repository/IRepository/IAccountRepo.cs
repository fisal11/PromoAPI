using Microsoft.AspNetCore.Identity;
using PromoAPI.Model;

namespace PromoAPI.Repository.IRepository
{
    public interface IAccountRepo
    {
        Task<IdentityResult> SignUp(SignUpModel signUpModel);
        Task<string> SignIn(SignInModel signInModel);
    }
}
