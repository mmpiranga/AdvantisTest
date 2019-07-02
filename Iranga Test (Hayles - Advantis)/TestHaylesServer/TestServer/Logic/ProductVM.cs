using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> BalanceAmount { get; set; }
    }
}
