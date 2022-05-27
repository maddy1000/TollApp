namespace TollApp.Pages.Models
{
    public class TollTransactionModel
    {

        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int UserId { get; set; }
        public int TollId { get; set; }





        public TollTransactionModel()
        {
            Id=0;
            Amount=0;
            TransactionDate=DateTime.Now;
            UserId = 0;
            TollId = 0;

        }


    }





}
