namespace ExpneseTracker.Core.ViewModels
{
    public class ExpenseViewModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string? Notes { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        //this is modified
    }
}