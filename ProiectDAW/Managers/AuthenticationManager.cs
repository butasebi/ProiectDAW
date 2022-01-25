using Microsoft.AspNetCore.Identity;
using ProiectDAW.Entities;
using ProiectDAW.Models;
using System.Threading.Tasks;

namespace ProiectDAW.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ITokenManager tokenManager;
        public AuthenticationManager(UserManager<User> userManager, SignInManager<User> signInManager, ITokenManager tokenManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenManager = tokenManager;
        }

        public async Task Signup(RegisterModel registerModel)
        {
            var user = new User
            {
                Email = registerModel.Email,
                UserName = registerModel.Email,
            };

            var result = await userManager.CreateAsync(user, registerModel.password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, registerModel.Role);
            }
        }
        public async Task<TokensModel> Login(LoginModel loginModel)
        {
            var user = await userManager.FindByNameAsync(loginModel.Email);
            if (user != null)
            {
                var result = await signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);// daca e true da lock la user sa nu mai intre in aplicatie
                if (result.Succeeded)
                {
                    var token = await tokenManager.Generate_Token(user);

                    return new TokensModel
                    {
                        AccessToken = token
                    };
                }
            }
            return null;
        }
    }
}
