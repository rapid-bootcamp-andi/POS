namespace POS.ViewModel.Response
{
    public class OrderDetailResponse
    {
        public int OrderDetailId { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }

        public int Quantity { get; set; }

        public int Discount { get; set; }

        public int Subtotal { get; set; }
    }
}
