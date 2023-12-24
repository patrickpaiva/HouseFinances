namespace HouseFinances.Entities
{
    public class RubricItem
    {
        public int BudgetItemID { get; set; }
        public string Name { get; set; } = String.Empty;
        public int ExpenseTypeID { get; set; }
        public required ExpenseType ExpenseType { get; set; }
    }
}
