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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(p => p.OrderID);
            builder.Property(p => p.OrderID).UseIdentityColumn();
            builder.Property(n => n.ProductID).IsRequired();
            builder.Property(n => n.UserID).IsRequired();
            builder.HasOne(n => n.AppUser).WithMany(n => n.Orders).HasForeignKey(n => n.UserID).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.Product).WithMany(n => n.Orders).HasForeignKey(n => n.ProductID).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
