using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesApi.Infra.Repository.Configure
{
    public class AmiiboConfiguration : IEntityTypeConfiguration<Amiibo>
    {
        public void Configure(EntityTypeBuilder<Amiibo> builder)
        {
            builder.ToTable("AmiibooData");
            builder.Property(x => x.Id).HasColumnType("int");
            builder.HasKey("Id");
            builder.Property(x => x.Type).HasColumnType("nvarchar(100)");
            builder.Property(x => x.Name).HasColumnType("nvarchar(100)");
            builder.Property(x => x.Image).HasColumnType("nvarchar(100)");
            builder.Property(x => x.Name).HasColumnType("nvarchar(100)");
            builder.Property(x => x.AmiiboSeries).HasColumnType("nvarchar(100)");
            //builder.Property(x => x.Character).HasColumnType("nvarchar(100)");
            builder.Property(x => x.Thecharacter).HasColumnType("nvarchar(100)");
            builder.Property(x => x.GameSeries).HasColumnType("nvarchar(100)");
            builder.Property(x => x.Head).HasColumnType("nvarchar(100)");
            builder.Property(x => x.Tail).HasColumnType("nvarchar(100)");
        }
    }
}
