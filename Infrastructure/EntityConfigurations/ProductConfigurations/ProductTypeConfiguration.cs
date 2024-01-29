using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entiys;

namespace Infrastructure.EntityConfigurations.EducationConfigurations;

public class ProductTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product", "dbo");

        builder.HasKey("Id");

        builder.Property(x => x.Name)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Name")
            .HasColumnType("nvarchar(255)")
            .IsRequired();
        
        builder.Property(x => x.ProduceDate)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("ProduceDate")
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(x => x.ManufacturePhone)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("ManufacturePhone")
            .HasColumnType("nvarchar(11)")
            .IsRequired();

        builder.Property(x => x.ManufactureEmail)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("ManufactureEmail")
            .HasColumnType("nvarchar(255)")
            .IsRequired();

        builder.Property(x => x.IsAvailable)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("IsAvailable")
            .HasColumnType("bit")
            .IsRequired();

        builder.Property(x => x.Deleted)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Deleted")
            .HasColumnType("bit")
            .IsRequired();

        builder.Property(x => x.UserId)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("UserId")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(y => y.Products)
            .HasForeignKey(z => z.UserId);


    }
}
