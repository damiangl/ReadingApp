using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ReadingApp.Shared.DTOs;
using ReadingApp.Shared.Entities;

namespace ReadingApp.WebAPI.MappingProfiles
{
    public class AccountMappingProfile : Profile
    {
        //private readonly IPasswordHasher<Account> passwordHasher;

        public AccountMappingProfile(/*IPasswordHasher<Account> passwordHasher*/)
        {
            //this.passwordHasher = passwordHasher;

            CreateMap<AccountCreateDto, Account>()
                .ForMember(m => m.Enabled, o => o.MapFrom(s => true))
                //.AfterMap((src, dest) =>
                //{
                //    dest.PasswordHash = passwordHasher.HashPassword(dest, src.Password);
                //})
                ;
            CreateMap<Account, AccountDto>();
            CreateMap<TokenDto, Account>();
        }
    }
}
