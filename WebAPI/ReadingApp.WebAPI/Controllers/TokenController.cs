using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ReadingApp.Infrastructure.DTOs;
using ReadingApp.WebAPI.DbContexts;
using ReadingApp.WebAPI.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReadingApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/token")]
    public class TokenController: ControllerBase
    {
        private readonly ITokenService tokenService;

        public TokenController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        [HttpPost]
        public ActionResult Post(TokenDto tokenDto)
        {
            var result = tokenService.Post(tokenDto);
            return Ok(result);
        }
   }
}
