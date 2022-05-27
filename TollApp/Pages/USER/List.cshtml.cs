using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TollApp.Pages.DataAccess;
using TollApp.Pages.Models;

namespace TollApp.Pages.USER
{
    public class ListModel : PageModel
    {
        public List<UserDataModel> UserRecords { get; set; }

        public ListModel()
        {
            UserRecords = new List<UserDataModel>();
        }
        public void OnGet()
        {
            var userDataAccess= new UserDataAccess();
            UserRecords = userDataAccess.GetAll();
        }
    }
}
