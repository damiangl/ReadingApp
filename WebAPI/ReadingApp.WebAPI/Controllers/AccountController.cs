using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadingApp.Shared.DTOs;
using ReadingApp.WebAPI.Services.Interfaces;

namespace ReadingApp.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost]
        public ActionResult Register(AccountCreateDto accountCreateDto)
        {
            var result = accountService.Create(accountCreateDto);
            return Ok(result);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = accountService.GetAll();
            return Ok(result);
        }
    }
}
