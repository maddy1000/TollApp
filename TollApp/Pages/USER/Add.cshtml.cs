using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TollApp.Pages.DataAccess;
using TollApp.Pages.Models;

namespace TollApp.Pages.USER
{
    public class AddModel : PageModel
    {

        [BindProperty]
        [Display(Name = "Name")]
        [Required]
   
        public string Name { get; set; }



        [BindProperty]
        [Display(Name = "Vehicle Number")]
        [Required]

        public string VehicleNumber { get; set; }



        [BindProperty]
        [Display(Name = "Mobile Number")]
        [Required]

        public string MobileNumber { get; set; }
        [BindProperty]
        [Display(Name = "Email")]
        [Required]

        public string EmailId { get; set; }
        [BindProperty]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [BindProperty]
        public List<SelectListItem> VehicleCategoryList { get; set; }
        [BindProperty]
        [Display(Name = "Category")]
        public int SelectedCategoryId { get; set; }


    
       

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public AddModel()
        {
            SuccessMessage = "";
            ErrorMessage = "";
            Name = "";
            MobileNumber = "";
            EmailId = "";
            Password = "";
            VehicleCategoryList = GetCategory();
            VehicleNumber = "";
            SelectedCategoryId = 0;

        }

      

        private List <SelectListItem> GetCategory()
        {
            var vehicleDataAccess = new VehicleDataAccess();
            var vehicles = vehicleDataAccess.GetAll();
            var vList = new List<SelectListItem>();

            foreach (var c in vehicles)
            {
                vList.Add(new SelectListItem
                {
                    Text = $"{c.VehicleCategory}",
                    Value = c.Id.ToString()
                });
            }

            return vList;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            VehicleCategoryList = GetCategory();
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data";
                return;
            }

           


            var userDataAccess = new UserDataAccess();
            var tripDataModel = new UserDataModel();
            var newUser = new UserDataModel {Name=Name,VehicleNumber=VehicleNumber,MobileNumber=MobileNumber,EmailId=EmailId,Password=Password,VehicleCategoryId=SelectedCategoryId };
            var result = userDataAccess.Insert(newUser);


            if (result)
            {
                SuccessMessage = "Successfully Inserted!";
                ErrorMessage = "";
            }
            else
            {
                ErrorMessage = $"Error adding Employee Course - {userDataAccess.ErrorMessage}";
                SuccessMessage = "";
            }


          
            Name = "";
            MobileNumber = "";
            EmailId = "";
            Password = "";
            VehicleCategoryList = GetCategory();
            VehicleNumber = "";
            SelectedCategoryId = 0;
        }













    }

}
