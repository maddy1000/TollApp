using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TollApp.Pages.DataAccess;

namespace TollApp.Pages.TOLL
{
    public class DeleteModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public string TollLocation { get; set; }


        public bool ShowButton { get; set; }
        public int TollDistance { get; set; }


        public int TollId { get; set; }


        public int TollPrice { get; set; }


        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public DeleteModel()
        {
            SuccessMessage = "";
            ErrorMessage = "";
            TollLocation = "";
            TollDistance = 0;
            TollPrice = 0;
            ShowButton = true;

            TollId = 0;
        }




        public void OnGet(int id)
        {
            Id = id;

            if (Id <= 0)
            {
                ErrorMessage = "Invalid Id";
                return;
            }

            var userDataAccess = new TollDataAccess();
            var user = userDataAccess.GetTollById(id);

            if (user != null)
            {
                TollId = user.Id;
            }
            else
            {
                ErrorMessage = "No Record found with that Id";
            }
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data";
                return;
            }

            var userDataAccess = new TollDataAccess();
            var numOfRows = userDataAccess.Delete(Id);
            if (numOfRows > 0)
            {
                SuccessMessage = $"Toll {TollId} deleted successfully!";
                ShowButton = false;
            }
            else
            {
                ErrorMessage = $"Error! Unable to delete Toll {TollId}";
            }
        }
    }
}
