using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infraestructure.Data.Config
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> entity)
        {
            entity.HasKey(e => e.CommentId);

            entity.ToTable("Comentario");

            entity.Property(e => e.CommentId).HasColumnName("IdComentario").ValueGeneratedNever();
            entity.Property(e => e.Description).
                HasColumnName("Descripcion")
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Date).HasColumnName("Fecha").HasColumnType("datetime");
            entity.Property(e => e.PostId).HasColumnName("IdPublicacion");
            entity.Property(e => e.UserId).HasColumnName("IdUsuario");
            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentario_Publicacion");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentario_Usuario");
        }
    }
}
