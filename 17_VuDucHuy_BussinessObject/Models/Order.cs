﻿using System;
using System.Collections.Generic;

namespace _17_VuDucHuy_BussinessObject.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int MemberId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal? Freight { get; set; }

        public virtual Member Member { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public Order(int memberId, DateTime orderDate, DateTime requiredDate, DateTime shippedDate, decimal freight, Member member)
        {
            MemberId = memberId;
            OrderDate = orderDate;
            RequiredDate = requiredDate;
            ShippedDate = shippedDate;
            Freight = freight;
        }
    }
}
