namespace TollApp.Pages.Models
{
    public class AllTransactionDataModel
    {





        public int TollId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string TollLocation { get; set; }

        public int Amount { get; set; }

        public DateTime TransactionDate { get; set; }





        public AllTransactionDataModel()
        {
            TollId = 0;
            Amount = 0;
            UserName = "";
            TollLocation = "";
;            TransactionDate = DateTime.Now;
            UserId = 0;
           
        }
    }
}
