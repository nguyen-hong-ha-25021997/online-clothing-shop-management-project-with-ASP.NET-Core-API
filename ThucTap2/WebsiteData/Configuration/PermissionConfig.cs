using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebsiteData.Entities;

namespace WebsiteData.Configuration
{
    public class PermissionConfig : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable(" Permission");
            builder.HasKey(t => t.AccountId);
            builder.Property(t => t.AccountId).IsRequired();
            builder.HasOne(x => x.Function).WithMany(x => x.Permissions).HasForeignKey(x => x.FunctionId);
        }
    }
}
