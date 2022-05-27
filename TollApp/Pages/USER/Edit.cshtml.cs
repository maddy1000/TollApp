using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TollApp.Pages.DataAccess;
using TollApp.Pages.Models;

namespace TollApp.Pages.USER
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

        public List<SelectListItem> VehicleCategoryList { get; set; }
        [BindProperty]
        [Display(Name = "Category")]

        public int SelectedCategoryId { get; set; }



      
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public EditModel()
        {
            SuccessMessage = "";
            ErrorMessage = "";
            Name = "";
            MobileNumber = "";
            EmailId = "";
         
            VehicleCategoryList = GetCategory();
            VehicleNumber = "";
            SelectedCategoryId = 0;

        }



        private List<SelectListItem> GetCategory()
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
        public void OnGet(int id)
        {
            VehicleCategoryList = GetCategory();
            Id = id;
            if (Id < 0)
            {
                ErrorMessage = "Invalid Id";
                return;
            }
            var userDataAccess = new UserDataAccess();
            var use = userDataAccess.GetUserById(id);
            if (use != null)
            {
                Name = use.Name;
                MobileNumber=use.MobileNumber;
                EmailId=use.EmailId;
               
                VehicleNumber= use.VehicleNumber;
               

            }

            else
            {
                ErrorMessage = "No record found with this id";
            }
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
            var newUser = new UserDataModel { Id=Id,Name = Name, VehicleNumber = VehicleNumber, MobileNumber = MobileNumber, EmailId = EmailId, VehicleCategoryId = SelectedCategoryId };
            var result = userDataAccess.Update(newUser);


            if (result)
            {
                SuccessMessage = "Successfully Updated!";
                ErrorMessage = "";
            }
            else
            {
                ErrorMessage = $"Error adding Employee Course - {userDataAccess.ErrorMessage}";
                SuccessMessage = "";
            }
        }
    }
}
