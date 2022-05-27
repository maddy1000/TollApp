using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TollApp.Pages.DataAccess;
using TollApp.Pages.Models;

namespace TollApp.Pages.TOLL
{
    public class ListModel : PageModel
    {
        public List<TollDataModel> TollRecords { get; set; }

        public ListModel()
        {
            TollRecords = new List<TollDataModel>();
        }
        public void OnGet()
        {
            var tollDataAccess = new TollDataAccess();
            TollRecords = tollDataAccess.GetAll();
        }
    }
}
