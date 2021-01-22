﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebsiteData.Entities;

namespace MyWebsite.Data.Configuration
{
    class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(p => p.Product_Id);
            builder.Property(p => p.Product_Id).IsRequired();
            builder.Property(p => p.Product_Name).IsRequired();
            builder.Property(p => p.Product_Price).IsRequired();
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.Category_Id);
        }
    }
}
