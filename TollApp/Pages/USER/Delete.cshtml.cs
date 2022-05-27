using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TollApp.Pages.DataAccess;

namespace TollApp.Pages.USER
{
    
    public class DeleteModel : PageModel
    {

        
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public bool ShowButton { get; set; }


      

        public string Name { get; set; }



    
      

        public string VehicleNumber { get; set; }





        public string MobileNumber { get; set; }

        public string EmailId { get; set; }


        public List<SelectListItem> VehicleCategoryList { get; set; }
    
        public int SelectedCategoryId { get; set; }




        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public DeleteModel()
        {
            SuccessMessage = "";
            ErrorMessage = "";
            Name = "";
            MobileNumber = "";
            EmailId = "";
            VehicleCategoryList = GetCategory();
            VehicleNumber = "";
            SelectedCategoryId = 0;
            ShowButton=true;

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
            id = Id;

            if (Id <= 0)
            {
                ErrorMessage = "Invalid Id";
                return;
            }

            var userDataAccess = new UserDataAccess();
            var user = userDataAccess.GetUserById(id);

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

            var userDataAccess = new UserDataAccess();
            var numOfRows = userDataAccess.Delete(Id);
            if (numOfRows > 0)
            {
                SuccessMessage = $"User {Id} deleted successfully!";
                ShowButton = false;
            }
            else
            {
                ErrorMessage = $"Error! Unable to delete User {Id}";
            }
        }
    }
}
