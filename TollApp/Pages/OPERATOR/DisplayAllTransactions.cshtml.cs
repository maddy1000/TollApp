using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TollApp.Pages.DataAccess;
using TollApp.Pages.Models;

namespace TollApp.Pages.OPERATOR
{
    public class DisplayAllTransactionsModel : PageModel
    {
        public List<AllTransactionDataModel> UserRecords { get; set; }

        public DisplayAllTransactionsModel()
        {
            UserRecords = new List<AllTransactionDataModel>();
        }
        public void OnGet()
        {
            var userTransactionDataAccess = new AllTransactionDataAccess();
            UserRecords = userTransactionDataAccess.GetAllTransaction();




        }
    }
}
