using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastrucure.Data.Config
{
    public class OrderConfigration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(p => p.ShipToAddress, a =>
            {
                a.WithOwner();
            });

            builder.Navigation( o => o.ShipToAddress).IsRequired();

            builder.Property(a => a.Status).HasConversion( o => o.ToString() ,

                o => (OrderStatus) Enum.Parse(typeof(OrderStatus) , o)
            );

            builder.HasMany(o => o.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
            

        }
    }
}
