using ReadingApp.Infrastructure.DTOs;

namespace ReadingApp.WebAPI.Services.Interfaces
{
    public interface IAccountService
    {
        int Create(AccountCreateDto accountCreateDto);
        IEnumerable<AccountDto> GetAll();
        void Delete();
        void Update();
    }
}