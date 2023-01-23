using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingApp.Infrastructure.DTOs
{
    public class AccountDto
    {
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }
    }
}
