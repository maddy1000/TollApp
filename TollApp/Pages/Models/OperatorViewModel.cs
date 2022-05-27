namespace TollApp.Pages.Models
{
    public class OperatorViewModel
    {



        public int UserId { get; set; }
        public string TollLocation { get; set; }

        public int Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}