using CaseStudy.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Data.Configuration
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(p => p.CartID);
            builder.Property(p => p.CartID).UseIdentityColumn();
            builder.Property(n => n.ProductID).IsRequired();
            builder.Property(n => n.UserID).IsRequired();
            builder.Property(n => n.Quantity).IsRequired();

            builder.HasOne(n => n.Product).WithMany(c => c.Carts).HasForeignKey(c => c.ProductID);
        }
    }
}
