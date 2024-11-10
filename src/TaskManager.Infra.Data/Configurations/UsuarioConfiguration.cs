using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;

namespace TaskManager.Infra.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasData(new Usuario
            {
                Id = new Guid("0f58ef89-c87e-4c09-a9ad-4cbc2f764aec"),
                Nome = "Jimmy Page"
            }, new Usuario
            {
                Id = new Guid("a69c1158-3c7e-4441-a3da-d060c2b5604c"),
                Nome = "Jimmy Hendrix"
            });
        }
    }
}
