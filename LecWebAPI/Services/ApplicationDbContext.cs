using LecWebAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LecWebAPI.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Pet> Pets => Set<Pet>();
}

