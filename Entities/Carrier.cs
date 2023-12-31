namespace HouseFinances.Entities
{
    public class Carrier
    {
        public int CarrierID { get; set; }
        public string Name { get; set; } = String.Empty;
        public required List<PaymentMethod> PaymentMethods { get; set; }
    }
}
