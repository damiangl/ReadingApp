using ReadingApp.Shared.DTOs;

namespace ReadingApp.WebAPI.Services.Interfaces
{
    public interface ITokenService
    {
        string Post(TokenDto tokenDto);
    }
}