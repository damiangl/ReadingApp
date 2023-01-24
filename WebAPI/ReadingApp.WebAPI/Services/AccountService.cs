using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using ReadingApp.Shared.DTOs;
using ReadingApp.Shared.Entities;
using ReadingApp.WebAPI.DbContexts;
using ReadingApp.WebAPI.Services.Interfaces;

namespace ReadingApp.WebAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly AuthDbContext dbContext;
        private readonly IMapper mapper;
        private readonly ILogger<AccountService> logger;
        private readonly IPasswordHasher<Account> passwordHasher;

        public AccountService(AuthDbContext dbContext, IMapper mapper, ILogger<AccountService> logger, IPasswordHasher<Account> passwordHasher)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.logger = logger;
            this.passwordHasher = passwordHasher;
        }

        public int Create(AccountCreateDto accountCreateDto)
        {
            if (dbContext.Accounts.Where(w => w.UserName.Equals(accountCreateDto.UserName)) == null)
                throw new Exception("User Name is already exists");
            var account = mapper.Map<Account>(accountCreateDto);
            account.PasswordHash = passwordHasher.HashPassword(account, accountCreateDto.Password);
            dbContext.Accounts.Add(account);
            dbContext.SaveChanges();
            return account.Id;
        }

        public IEnumerable<AccountDto> GetAll()
        {
            var accounts = dbContext.Accounts.Where(w => w.Enabled);
            var accountDtos = mapper.Map<List<AccountDto>>(accounts);
            return accountDtos;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
