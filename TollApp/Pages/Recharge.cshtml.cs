using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using TollApp.Pages.DataAccess;
using TollApp.Pages.Models;

namespace TollApp.Pages
{
    public class RechargeModel : PageModel
    {
        //[BindProperty(SupportsGet = true)]
        //public int Id { get; set; }

        [BindProperty]
        [Display(Name = "Amount")]
        [Required]

        public int Amount { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public void OnGet()
        {

            //Id = id;
            //if (Id < 0)
            //{
            //    ErrorMessage = "Invalid Id";
            //    return;
            //}
            //var userDataAccess = new UserDataAccess();
            //var use = userDataAccess.GetUserById(id);
            //if (use != null)
            //{
            //    Amount = use.BalanceAmount;
                


            //}

            //else
            //{
            //    ErrorMessage = "No record found with this id";
            //}


        }


        public void OnPost()
        {
           
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data";
                return;
            }


            //var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var userId = HttpContext.Session.GetInt32("UserId").Value;

            var userDataAccess = new UserDataAccess();
            var tripDataModel = new UserDataModel();
            var newUser = new UserDataModel { BalanceAmount=Amount };
            var result = userDataAccess.UpdateAmount(newUser,userId);


            if (result)
            {
                SuccessMessage = "Successfully Recharged!";
                ErrorMessage = "";
            }
            else
            {
                ErrorMessage = $"Error Updating - {userDataAccess.ErrorMessage}";
                SuccessMessage = "";
            }
        }

    }
}
