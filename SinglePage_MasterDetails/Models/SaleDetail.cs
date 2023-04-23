using System;
using System.Collections.Generic;

namespace SinglePage_MasterDetails.Models
{
    public partial class SaleDetail
    {
        public long SaleDetailId { get; set; }
        public long? SaleId { get; set; }
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
        public decimal? Qty { get; set; }
    }
}
