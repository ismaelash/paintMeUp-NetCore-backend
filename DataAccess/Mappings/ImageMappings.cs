using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Mappings
{
    public class ImageMappings : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Image");
            builder.HasKey("Id");
            builder.Property(x => x.Username);
            builder.Property(x => x.UrlImage);
            builder.Property(x => x.Likes);
        }
    }
}
