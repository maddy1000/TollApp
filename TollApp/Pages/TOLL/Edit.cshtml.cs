using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TollApp.Pages.DataAccess;
using TollApp.Pages.Models;

namespace TollApp.Pages.TOLL
{
    public class EditModel : PageModel
    {


        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

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

        public EditModel()
        {
            SuccessMessage = "";
            ErrorMessage = "";
            TollLocation = "";
            TollDistance = 0;
            TollPrice = 0;


        }






        public void OnGet(int id)
        {
          
            Id = id;
            if (Id < 0)
            {
                ErrorMessage = "Invalid Id";
                return;
            }
            var userDataAccess = new TollDataAccess();
            var toll = userDataAccess.GetTollById(id);
            if (toll != null)
            {
                TollLocation = toll.TollLocation;
                TollDistance=toll.TollDistance;
                TollPrice=toll.TollPrice;


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





            var tollDataAccess = new TollDataAccess();
            var newToll = new TollDataModel { Id=Id,TollLocation = TollLocation, TollDistance = TollDistance, TollPrice = TollPrice };
            var result = tollDataAccess.Update(newToll);


            if (result != null )
            {
                SuccessMessage = "Successfully Updated!";
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
