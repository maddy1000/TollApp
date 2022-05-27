using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TollApp.Pages.DataAccess;
using TollApp.Pages.Models;
using Microsoft.Extensions.Identity.Core;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;



namespace TollApp.Pages
{
    public class TransactionModel : PageModel
    {
       
        public List<UserDataViewModel> UserRecords { get; set; }

        public TransactionModel()
        {
            UserRecords = new List<UserDataViewModel>();
        }
        public void OnGet()
        {
            var userTransactionDataAccess = new UserTransactionDataAccess();
            UserRecords = userTransactionDataAccess.GetAllTransaction();



           
        }
    }
}
