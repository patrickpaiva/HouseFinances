namespace HouseFinances.Entities
{
    public class Carrier
    {
        public int CarrierID { get; set; }
        public string Description { get; set; } = String.Empty;
        public int CarrierTypeID {  get; set; }
        public int PersonID { get; set; }
        public required CarrierType CarrierType { get; set; }
        public required List<PaymentMethod> PaymentMethods { get; set; }
        public required Person Person { get; set; }
    }
}
