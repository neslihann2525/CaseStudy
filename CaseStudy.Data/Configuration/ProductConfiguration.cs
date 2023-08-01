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
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductID);
            builder.Property(p => p.ProductID).UseIdentityColumn();
            builder.Property(n => n.Name).IsRequired();
            builder.Property(n => n.Price).IsRequired();
            builder.Property(n=>n.Quantity).IsRequired();
        }
    }
}
