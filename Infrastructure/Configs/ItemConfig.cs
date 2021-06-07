using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configs
{
    public class ItemConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(item => item.Id);

            builder.HasMany(item => item.Discounts).WithOne(discount => discount.Item).HasForeignKey(discount => discount.ItemId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(item => item.Price).HasColumnType("decimal(18,4)");

            builder.HasMany(item => item.CartItems).WithOne(cartItem => cartItem.Item).HasForeignKey(cartItem => cartItem.ItemId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
