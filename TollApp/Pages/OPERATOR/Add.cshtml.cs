using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TollApp.Pages.DataAccess;
using TollApp.Pages.Models;

namespace TollApp.Pages.OPERTOR
{
    public class AddModel : PageModel
    {
        [BindProperty]
        [Display(Name = "Name")]
        [Required]

        public string Name { get; set; }



        [BindProperty]
        [Display(Name = "MobileNumber")]
        [Required]
        [MaxLength(10)]
        [MinLength(10)]

        public string MobileNumber { get; set; }



        [BindProperty]
        [Display(Name = "Email Id")]
        [Required]

        public string EmailId { get; set; }
        
        [BindProperty]
        [Display(Name = "Password")]
        public string Password { get; set; }
       





        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

       



    
        public void OnGet()
        {
            ModelState.Clear();
            Name = "";
            SuccessMessage = "";
            ErrorMessage = "";
          
            MobileNumber = "";
            EmailId = "";
            Password = "";

        }

        public void OnPost()
        {
            ModelState.Clear();

            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data";
                return;
            }



            //var a = new OperatorDataModel();
            //if (a.IsValid() == false)
            //{
            //    ErrorMessage = "Mobile Number should be of 10 digits";
            //    return;

            //}

            var operatorDataAccess = new OperatorDataAccess();
            var newOperator = new OperatorDataModel { Name = Name, MobileNumber = MobileNumber, EmailId = EmailId, Password = Password };
            var result = operatorDataAccess.Insert(newOperator);


            if (result != null && result.Id > 0)
            {
                SuccessMessage = "Successfully Inserted!";
                ErrorMessage = "";
            }
            else
            {
                ErrorMessage = $"Error Already Registered";
                SuccessMessage = "";
            }


            ModelState.Clear();
            Name = "";
            SuccessMessage = "";
            ErrorMessage = "";

            MobileNumber = "";
            EmailId = "";
            Password = "";
        }
    }
}
