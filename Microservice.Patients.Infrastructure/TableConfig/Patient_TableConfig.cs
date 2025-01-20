using Microservice.Patients.Domain.Patient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservice.Patients.Infrastructure.TableConfig
{
    public class Patient_TableConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patient");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Dni).HasColumnName("Dni").IsRequired();
            builder.Property(p => p.Name).HasColumnName("Name").HasMaxLength(50).HasField("_name");
            builder.Property(p => p.LastName).HasColumnName("LastName").HasMaxLength(50).HasField("_lastname");
            builder.Property(p => p.Status).HasColumnName("Status");

            builder.OwnsOne(u => u.Phone, phoneBuilder =>
            {
                phoneBuilder.Property(e => e.Value)
                            .HasColumnName("phone")
                            .HasMaxLength(50)
                            .IsRequired();
                phoneBuilder.HasIndex(e => e.Value).IsUnique();
            });
            builder.OwnsOne(u => u.Email, emailBuilder =>
            {
                emailBuilder.Property(e => e.Value)
                            .HasColumnName("email")
                            .HasMaxLength(50)
                            .IsRequired();
                emailBuilder.HasIndex(e => e.Value).IsUnique();
            });
            builder.OwnsOne(u => u.Password, passBuilder =>
            {
                passBuilder.Property(e => e.Value)
                            .HasColumnName("password")
                            .HasMaxLength(50)
                            .IsRequired();
                passBuilder.HasIndex(e => e.Value).IsUnique();
            });



        }
    }
}
