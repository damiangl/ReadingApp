using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ReadingApp.Shared.DTOs;
using ReadingApp.Shared.Entities;
using ReadingApp.WebAPI.DbContexts;
using ReadingApp.WebAPI.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReadingApp.WebAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        private readonly AuthDbContext dbContext;
        private readonly ILogger<TokenService> logger;
        private readonly IMapper mapper;
        private readonly IPasswordHasher<Account> passwordHasher;

        public TokenService(IConfiguration configuration, AuthDbContext dbContext, ILogger<TokenService> logger, IMapper mapper, IPasswordHasher<Account> passwordHasher)
        {
            this.configuration = configuration;
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
            this.passwordHasher = passwordHasher;
        }

        public string Post(TokenDto tokenDto)
        {
            var account = dbContext.Accounts.Where(w => w.Enabled && w.UserName.Equals(tokenDto.UserName)).FirstOrDefault();
            if (account == null)
                throw new Exception("Account doesn't exist");
            var verifyHashedPassword = passwordHasher.VerifyHashedPassword(account, account.PasswordHash, tokenDto.Password);
            if (verifyHashedPassword == PasswordVerificationResult.Failed)
                throw new Exception("Password is invalid");
            else if (verifyHashedPassword == PasswordVerificationResult.SuccessRehashNeeded)
                this.RehashPassword(tokenDto);
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserName", account.UserName)
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            return (new JwtSecurityTokenHandler().WriteToken(token));
        }

        private void RehashPassword(TokenDto tokenDto)
        {
            var account = dbContext.Accounts.Where(w => w.UserName.Equals(tokenDto.UserName)).FirstOrDefault();
            account.PasswordHash = passwordHasher.HashPassword(account, tokenDto.Password);
            dbContext.SaveChanges();
        }
    }
}
