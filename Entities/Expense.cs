namespace HouseFinances.Entities
{
    public class Expense
    {
        public int ExpenseID { get; set; }
        public int ExpenseTypeID { get; set; }
        public int BudgetItemID { get; set; }
        public int PersonID { get; set; }
        public DateTime Date { get; set; }
        public string Observation { get; set; } = String.Empty;
        public decimal Amount { get; set; }
        public string Status { get; set; } = String.Empty;
        public int PaymentMethodID { get; set; }
        public int CarrierID { get; set; }
        public int Installments { get; set; }

        public required ExpenseType ExpenseType { get; set; }
        public required RubricItem RubricItem { get; set; }
        public required Person Person { get; set; }
        public required PaymentMethod PaymentMethod { get; set; }
        public required Carrier Carrier { get; set; }
    }
}
