using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadingApp.Infrastructure.DTOs;
using ReadingApp.Infrastructure.Entities;
using ReadingApp.WebAPI.Services;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ReadingApp.WebAPI.DbContexts
{
    public class ReadingDbContext : DbContext
    {
        public DbSet<Reading> Readings { get; set; }
        public DbSet<ReadingItem> ReadingItems { get; set; }

        public ReadingDbContext(DbContextOptions<ReadingDbContext> options) : base(options)
        {

        }

    }
}
