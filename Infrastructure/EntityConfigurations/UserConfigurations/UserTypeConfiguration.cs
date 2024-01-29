using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entiys;

namespace Infrastructure.EntityConfigurations.UserConfigurations;

public class UserTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User", "dbo");

        builder.HasKey("Id");

        builder.Property(x => x.UserName)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("UserName")
            .HasColumnType("nvarchar(255)")
            .IsRequired();

        builder.Property(x => x.Password)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Password")
            .HasColumnType("nvarchar(16)")
            .IsRequired();

    }
}
