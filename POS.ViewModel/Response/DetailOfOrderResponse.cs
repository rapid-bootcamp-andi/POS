namespace POS.ViewModel.Response
{
    public class DetailOfOrderResponse
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public DateTime ShippedDate { get; set; }

        public int ShipperId { get; set; }
        public string ShipperName { get; set; }
        public string ShipperPhone { get; set; }

        public int Freight { get; set; }

        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public List<OrderDetailResponse> Detail { get; set; }

        public double Subtotal { get; set; }
        public double Tax { get; set; }
        public double Shipping { get; set; }
        public double Total { get; set; }
    }
}
