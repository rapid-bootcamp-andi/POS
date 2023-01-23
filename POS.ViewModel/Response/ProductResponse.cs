namespace POS.ViewModel.Response
{
    public class ProductResponse
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public int UnitInOrder { get; set; }
        public int ReorderLevel { get; set; }
        public int Discontinued { get; set; }
    }
}
