using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infraestructure.Data.Config
{
        public class PostConfig : IEntityTypeConfiguration<Post>
        {
            public void Configure(EntityTypeBuilder<Post> entity)
            {
                entity.HasKey(e => e.PostId);
                entity.ToTable("Publicacion");

                entity.Property(e => e.PostId).HasColumnName("IdPublicacion");

                entity.Property(e => e.Description)
                    .HasColumnName("Descripcion")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("Fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Image)
                    .HasColumnName("Imagen")
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.UserId).HasColumnName("IdUsuario");
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Publicacion_Usuario");
            }
        }
    
}
