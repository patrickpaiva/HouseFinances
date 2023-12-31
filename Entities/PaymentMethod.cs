namespace HouseFinances.Entities
{
    public class PaymentMethod
    {
        public int PaymentMethodID { get; set; }
        public string Name { get; set; } = String.Empty;
        public int CarrierId { get; set; }
        public required Carrier Carrier { get; set; }
    }
}
