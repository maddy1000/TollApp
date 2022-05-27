using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TollApp.Pages.DataAccess;
using TollApp.Pages.Models;

namespace TollApp.Pages.OPERATOR
{
    public class EditModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        [Display(Name = "Name")]
        [Required]

        public string Name { get; set; }



        [BindProperty]
        [Display(Name = "MobileNumber")]
        [Required]

        public string MobileNumber { get; set; }



        [BindProperty]
        [Display(Name = "Email Id")]
        [Required]

        public string EmailId { get; set; }

   






        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public EditModel()
        {
            SuccessMessage = "";
            ErrorMessage = "";
            Name = "";
            MobileNumber = "";
            EmailId = "";
         


        }




        public void OnGet(int id)




        {
          
            Id = id;
            if (Id < 0)
            {
                ErrorMessage = "Invalid Id";
                return;
            }
            var operatorDataAccess = new OperatorDataAccess();
            var op = operatorDataAccess.GetOperatorById(id);
            if (op != null)
            {
                Name = op.Name;
                MobileNumber = op.MobileNumber;
                EmailId = op.EmailId;

               


            }

            else
            {
                ErrorMessage = "No record found with this id";
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
            var newOperator = new OperatorDataModel { Id=Id,Name = Name, MobileNumber = MobileNumber, EmailId = EmailId};
            var result = operatorDataAccess.Update(newOperator);


            if (result != null )
            {
                SuccessMessage = "Successfully Updated!";
                ErrorMessage = "";
            }
            else
            {
                ErrorMessage = $"Error adding Operator - {operatorDataAccess.ErrorMessage}";
                SuccessMessage = "";
            }
        }
    }
}
