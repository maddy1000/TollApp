using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TollApp.Pages.DataAccess;
using TollApp.Pages.Models;

namespace TollApp.Pages.TOLL
{
    public class AddModel : PageModel
    {
        [BindProperty]
        [Display(Name = "Toll Location")]
        [Required]

        public string TollLocation { get; set; }



        [BindProperty]
        [Display(Name = "Toll Distance")]
        [Required]

        public int TollDistance { get; set; }



        [BindProperty]
        [Display(Name = "Toll Price")]
        [Required]

        public int TollPrice { get; set; }


        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public AddModel()
        {
            SuccessMessage = "";
            ErrorMessage = "";
            TollLocation = "";
            TollDistance = 0;
            TollPrice = 0;


        }






        public void OnGet()
        {
        }

        public void OnPost()
        {


            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data";
                return;
            }





            var tollDataAccess = new TollDataAccess();
            var newToll = new TollDataModel { TollLocation = TollLocation, TollDistance=TollDistance,TollPrice=TollPrice };
            var result = tollDataAccess.Insert(newToll);


            if (result != null && result.Id > 0)
            {
                SuccessMessage = "Successfully Inserted!";
                ErrorMessage = "";
            }
            else
            {
                ErrorMessage = $"Error adding Operator - {tollDataAccess.ErrorMessage}";
                SuccessMessage = "";
            }
        }


    }
}
