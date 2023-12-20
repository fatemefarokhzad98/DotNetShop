﻿using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Entities
{
    public partial class Order
    {
        
        public int Id { get; set; }
        public long AmountPaid { get; set; }
        public string DispatchNumber { get; set; } = null!;
        public DateTime BuyDate { get; set; }
        public int Count { get; set; }
        public int StatusId { get; set; }
        public int UserId { get; set; }

        public virtual Status Status { get; set; } = null!;
        public virtual AppUser User { get; set; } = null!;
        public  virtual ICollection<ProductOrder> Products { get; set; } = null!;






    }
}