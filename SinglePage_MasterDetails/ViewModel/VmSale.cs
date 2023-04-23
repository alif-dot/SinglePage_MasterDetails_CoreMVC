namespace SinglePage_MasterDetails.ViewModel
{
    public class VmSale
    {
        public long SaleId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerAddress { get; set; }
        public string? Gender { get; set; }
        public string[]? ProductName { get; set; }
        public decimal[]? Price { get; set; }
        public decimal[]? Qty { get; set; }
        public List<VmSaleDetail> SaleDetails { get; set; } = new List<VmSaleDetail>();
        public class VmSaleDetail
        {
            public long SaleDetailId { get; set; }
            public long? SaleId { get; set; }
            public string? ProductName { get; set; }
            public decimal? Price { get; set; }
            public decimal? Qty { get; set; }
        }
    }
}
