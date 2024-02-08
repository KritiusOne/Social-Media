using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enumeraciones;

namespace SocialMedia.Infraestructure.Data.Config
{
    public class SecurityConfig : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Seguridad");

            entity.Property(e => e.Id).HasColumnName("IdSeguridad").ValueGeneratedNever();
            entity.Property(e => e.User).
                HasColumnName("Usuario")
                .HasMaxLength(100)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.UserName).HasColumnName("NombreUsuario").HasMaxLength(100).IsUnicode(false).IsRequired();
            entity.Property(e => e.Password).HasColumnName("Contrasena").HasMaxLength(100).IsUnicode(false).IsRequired();
            entity.Property(e => e.Role).HasColumnName("Rol").HasMaxLength(15).IsUnicode(false).IsRequired()
                .HasConversion(x=>x.ToString(), x=> (Roles)Enum.Parse(typeof(Roles), x) );
        }
    }
}
