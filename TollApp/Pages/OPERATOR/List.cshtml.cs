using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TollApp.Pages.DataAccess;
using TollApp.Pages.Models;

namespace TollApp.Pages.OPERATOR
{
    public class ListModel : PageModel
    {
        public List<OperatorDataModel> OperatorRecords { get; set; }

        public ListModel()
        {
            OperatorRecords = new List<OperatorDataModel>();
        }
        public void OnGet()
        {
            var operatorDataAccess = new OperatorDataAccess();
            OperatorRecords = operatorDataAccess.GetAll();
        }
    }
}
