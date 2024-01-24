using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infraestructure.Data.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("Usuario");
            entity.Property(e => e.UserId).HasColumnName("IdUsuario");
            entity.Property(e => e.LastName)
                .HasColumnName("Apellidos")
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasColumnName("Email")
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirth).HasColumnName("FechaNacimiento").HasColumnType("date");
            entity.Property(e => e.FirstName).HasColumnName("Nombres")
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone).HasColumnName("Telefono")
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.isActive).HasColumnName("Activo");
        }
    }
}
