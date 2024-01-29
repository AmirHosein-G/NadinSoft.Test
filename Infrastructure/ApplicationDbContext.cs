using Application.Abstractions;
using Domain.Abstractions;
using Domain.Entiys;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infrastructure;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options): base(options)
    { }

    #region Db sets
    public virtual DbSet<User> Users{ get; set; }
    public virtual DbSet<Product> Products{ get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
}
