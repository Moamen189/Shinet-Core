using Core.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class OrderWithItemsAndOrderingSpecification :BaseSpecification<Order>
    {

        public OrderWithItemsAndOrderingSpecification(string email):base(o => o.BuyerEmail == email )
        {

            addIncludes(o => o.OrderItems);
            addIncludes(o => o.DeliveryMethod);

            AddOrderByDesending(o => o.OrderDate);


        }

        public OrderWithItemsAndOrderingSpecification(int id , string email):base(o => o.Id == id && o.BuyerEmail == email )
        {

            addIncludes(o => o.OrderItems);
            addIncludes(o => o.DeliveryMethod);

        }
    }
}
