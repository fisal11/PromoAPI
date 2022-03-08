﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PromoAPI.Model;
using PromoAPI.Repository.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PromoAPI.Repository
{
    public class Account :IAccountRepo
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public Account(UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager
            , IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult>SignUp(SignUpModel signUpModel)
        {
            var user = new ApplicationUser()
            {
                FirstName = signUpModel.FirstName,
                LastNamed = signUpModel.LastName,
                Email = signUpModel.Email,
                UserName = signUpModel.Email,

            };
            return await _userManager.CreateAsync(user, signUpModel.Password);
        }
    
        public async Task<string> SignIn(SignInModel signInModel){

            var result = await _signInManager.PasswordSignInAsync(
                signInModel.Email, signInModel.Password, false, false);
            if (!result.Succeeded){
                return null;
            }
            var authClims = new List<Claim>{
              
                new Claim(ClaimTypes.Name,signInModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var authSignKey = new SymmetricSecurityKey(
               Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT: ValidIssuer"],
                audience : _configuration["JWT:ValidAudience"],
                expires : DateTime.Now.AddDays(1),
                claims: authClims,
                signingCredentials : new SigningCredentials(
                    authSignKey , SecurityAlgorithms.HmacSha256Signature));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    
    }
}
 