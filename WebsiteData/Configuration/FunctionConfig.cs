using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebsiteData.Entities;

namespace WebsiteData.Configuration
{
    class FunctionConfig : IEntityTypeConfiguration<Function>
    {
        public void Configure(EntityTypeBuilder<Function> builder)
        {
            builder.ToTable(" Function");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).IsRequired();
        }
    }
}
