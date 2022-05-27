using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TollApp.Pages.DataAccess;

namespace TollApp.Pages.OPERATOR
{
    public class DeleteModel : PageModel
    {


        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public bool ShowButton { get; set; }

   

        public string Name { get; set; }



      


        public string MobileNumber { get; set; }



       

        public string EmailId { get; set; }

  
        public string Password { get; set; }






        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }






        public  DeleteModel()
        {
            ModelState.Clear();
            Name = "";
            SuccessMessage = "";
            ErrorMessage = "";

            MobileNumber = "";
            EmailId = "";
            Password = "";
            ShowButton = true;

        }




        public void OnGet(int id)
        {
            id = Id;

            if (Id <= 0)
            {
                ErrorMessage = "Invalid Id";
                return;
            }

            var operatorDataAccess = new OperatorDataAccess();
            var user = operatorDataAccess.GetOperatorById(id);

            if (user != null)
            {
                Name = user.Name;
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

            var operatorDataAccess = new OperatorDataAccess();
            var numOfRows = operatorDataAccess.Delete(Id);
            if (numOfRows > 0)
            {
                SuccessMessage = $"Operator {Id} deleted successfully!";
                ShowButton = false;
            }
            else
            {
                ErrorMessage = $"Error! Unable to delete User {Id}";
            }
        }



    }
}
