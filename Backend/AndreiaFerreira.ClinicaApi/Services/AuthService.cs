using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using AndreiaFerreira.ClinicaApi.Interfaces;
using AndreiaFerreira.ClinicaApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace AndreiaFerreira.ClinicaApi.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _cofiguration;

    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _cofiguration = configuration;
    }


    public async Task<string> Login(LoginModel model)
    {
        var user = await _userManager.FindByNameAsync(model.UserName);

        if (user != null)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (result.Succeeded)
            {
                var signingKey = _cofiguration["Jwt:SigningKey"];

                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, model.UserName)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(120),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey)), SecurityAlgorithms.HmacSha256),
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenstring = tokenHandler.WriteToken(token);

                return tokenstring;
            }
            else
            {
                throw new HttpRequestException("Incorrect credentials", null, HttpStatusCode.Unauthorized);
            }
        }
        else
        {
            throw new HttpRequestException("User not found", null, HttpStatusCode.NotFound);
        }
    }

    public async Task<bool> Register(RegisterModel model)
    {

        var user = new User()
        {
            UserName = model.UserName,
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            return true;
        }
        throw new HttpRequestException(result.Errors.First().Description, null, HttpStatusCode.BadRequest);
    }
}
