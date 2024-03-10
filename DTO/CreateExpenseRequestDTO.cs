namespace HouseFinances.DTO
{
    public class CreateExpenseRequestDTO
    {
        public int ExpenseTypeID { get; set; }
        public int RubricItemID { get; set; }
        public int PersonID { get; set; }
        public DateTime Date { get; set; }
        public required string Observation { get; set; }
        public decimal Amount { get; set; }
        public required string Status { get; set; }
        public int PaymentMethodID { get; set; }
        public int CarrierID { get; set; }
        public int Installments { get; set; }
    }
}
