using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebsiteData.Entities;

namespace MyWebsite.Data.Configuration
{
    class OrderConfig: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(p => p.Order_Id);
            builder.Property(p => p.Order_Id).IsRequired();
            builder.Property(p => p.Order_PurchaseTime).IsRequired().HasDefaultValueSql("GetDate()");
            builder.HasOne(p => p.Account).WithMany(p => p.Orders).HasForeignKey(p => p.Account_Id);
        }
    }
}
