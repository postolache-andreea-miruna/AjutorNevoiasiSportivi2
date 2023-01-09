﻿using AjutorNevoiasiSportivi2.Entities;
using AjutorNevoiasiSportivi2.Models;
using Microsoft.AspNetCore.Identity;

namespace AjutorNevoiasiSportivi2.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ITokenManager tokenManager;
        public AuthenticationManager(UserManager<User>userManager,
            SignInManager<User> signInManager,ITokenManager tokenManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenManager = tokenManager;
        }
        public async Task Signup(SignupUserModel signupUserModel)
        {
            var user = new User
            {
                Email = signupUserModel.Email,
                UserName = signupUserModel.Email
            };
            var result = await userManager.CreateAsync(user,signupUserModel.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, signupUserModel.RoleId);
            }
           //throw new NotImplementedException();
        }
        public async Task<TokenModel> Login(LoginUserModel loginUserModel)
        {
            //verif daca user exista
            var user = await userManager.FindByEmailAsync(loginUserModel.Email);
            if (user !=null)
            {
                var result = await signInManager.CheckPasswordSignInAsync(user, loginUserModel.Password, false);
                if (result.Succeeded)
                {
                    var token = await tokenManager.CreateToken(user);
                    return new TokenModel
                    {
                        Token = token
                    };
                }
            }
            return null;
            //throw new NotImplementedException();
        }

        public async Task<IList<string>> Rol(LoginUserModel loginUserModel)
        {
            var user = await userManager.FindByEmailAsync(loginUserModel.Email);
            if (user != null)
            {
                var role = await userManager.GetRolesAsync(user);
                return role;
            }
            return null;
        }


    }
}
