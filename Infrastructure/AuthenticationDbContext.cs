using Application.Abstractions;
using Domain.Abstractions;
using Domain.Entiys;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace Infrastructure;

public partial class AuthenticationDbContext : IdentityDbContext<IdentityUser>
{
    public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options)
            : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
