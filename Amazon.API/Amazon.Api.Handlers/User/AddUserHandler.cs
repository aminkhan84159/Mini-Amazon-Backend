using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Data.Entities;
using Amazon.Api.Entities.Communication;
using Amazon.Api.Entities.Messages.User;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace Amazon.Api.Handlers.User
{
    public class AddUserHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IUserDataService _userDataService,
        ICartService _cartService,
        ICommunicationService _communicationService,
        IConfiguration _configuration)
        : HandlerBase<AddUserRequest, AddUserResponse>(_logger, _amazonContext)
    {
        protected async override Task<bool> HandleCoreAsync()
        {
            var existingUser = await _userDataService.GetAll()
                .FirstOrDefaultAsync(x => x.IsActive == true && (x.Email == Request.Email || x.Username == Request.Username || x.PhoneNo == Request.PhoneNo));

            if (existingUser is not null)
            {
                if (existingUser.Email == Request.Email)
                    return Conflict($"Email {Request.Email} already exists");

                if (existingUser.Username == Request.Username)
                    return Conflict($"Username {Request.Username} already exists");

                if (existingUser.PhoneNo == Request.PhoneNo)
                    return Conflict($"Phone number {Request.PhoneNo} already exists");
            }

            var user = new Data.Entities.User()
            {
                FirstName = Request.FirstName,
                LastName = Request.LastName,
                Email = Request.Email,
                Username = Request.Username,
                Password = Request.Password,
                PhoneNo = Request.PhoneNo,
                Role = Request.Role,
                CreatedOn = DateTime.UtcNow,
                IsActive = true
            };

            //await _userDataService.AddAsync(user);

            var cart = new Data.Entities.Cart()
            {
                UserId = user.UserId,
                CreatedBy = user.UserId,
                CreatedOn = DateTime.UtcNow,
                IsActive = true
            };

            //await _cartService.AddAsync(cart);

            var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]!),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("Role", user.Role)
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: signIn
                );
            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            var welcomeEmailDto = WelcomeEmailDto.MapToEmail(Request.FirstName, Request.LastName, Request.Email, Request.Role);

            await _communicationService.SendEmailAsync(welcomeEmailDto.RecipientEmail, welcomeEmailDto.Subject, welcomeEmailDto.Body);

            Response.token = tokenValue.ToString();
            return Success();
        } 
    }
}
