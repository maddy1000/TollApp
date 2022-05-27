using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using TollApp.Pages.DataAccess;
using TollApp.Pages.Models;

namespace TollApp.Pages.USER
{
    public class UserTransactionListModel : PageModel
    {
        public List<UserDataViewModel> UserRecords1 { get; set; }
        [BindProperty]
        public int result1 { get; set; }
        public void OnGet()
        {
                var userId = HttpContext.Session.GetInt32("UserId").Value;

            var userDataAccess = new UserDataAccess();
            result1 = userDataAccess.GetBalanceById(userId);


            var userTransactionDataAccess = new UserTransactionDataAccess();
            UserRecords1 = userTransactionDataAccess.GetUser(userId);





        }
    }
}
