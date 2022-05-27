using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TollApp.Pages.DataAccess;
using TollApp.Pages.Models;

namespace TollApp.Pages
{
    public class AdminDashboardModel : PageModel
    {
        [BindProperty]
        public DashboardDataModel Dashboard { get; set; }

        public void OnGet()
        {
            var d = new DashboardDataAccess();
            Dashboard = d.GetAll();
        }
    }
}
