using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using TollApp.Pages.DataAccess;
using TollApp.Pages.Models;

namespace TollApp.Pages
{
    public class AddTransactionModel : PageModel
    {
    
  
        [BindProperty]
        [Display(Name = "Toll Id")]
        public int SelectedTollId { get; set; }

        [BindProperty]
        public List<SelectListItem> TollList { get; set; }


        public int Amount { get; set; }
        public DateTime TransactionDate { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public AddTransactionModel()
        {
            SuccessMessage = "";
            ErrorMessage = "";
          
            SelectedTollId = 0;
            TollList = GetToll();
            TransactionDate= DateTime.Now;
            Amount = 0;
        }


       

        private List<SelectListItem> GetToll()
        {
            var tollDataAccess = new TollDataAccess();
            var tolls = tollDataAccess.GetAll();
            var tollList = new List<SelectListItem>();

            foreach (var c in tolls)
            {
               tollList.Add(new SelectListItem
                {
                    Text = $"{c.TollLocation}-{c.Id}",
                    Value = c.Id.ToString()
                });
            }

            return tollList;
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
            TollList = GetToll();

            var userId = HttpContext.Session.GetInt32("UserId").Value;
            var vehicleId = HttpContext.Session.GetInt32("VehicleId").Value;


            var transactionDataAccess = new UserTransactionDataAccess();
            var tollDataModel = new TollTransactionModel();

            var tollDataAccess = new TollDataAccess();
            var toll = tollDataAccess.GetTollById(SelectedTollId);
            var vehicleDataAccess = new VehicleDataAccess();
            var vehicle = vehicleDataAccess.GetCostById(vehicleId);

            var amount = toll.TollPrice + vehicle.Cost;

            var userDataAccess = new UserDataAccess();
            var balance1 = userDataAccess.GetBalanceById(userId);
            if(balance1 < amount)
            {
                ErrorMessage = $"Invalid Balance Amount - {balance1}";
                return;
            }

            var newtrip = new TollTransactionModel { Amount = amount, TollId = SelectedTollId, UserId = userId};
            var result = transactionDataAccess.Insert(newtrip);


            if (result)
            {
                var serDataAccess = new UserDataAccess();
                var balance = serDataAccess.GetBalanceById(userId);
                HttpContext.Session.SetInt32("Balance", balance);

                SuccessMessage = "Successfully Inserted!";
                ErrorMessage = "";
            }
            else
            {
                ErrorMessage = $"Error Insertion failed - {transactionDataAccess.ErrorMessage}";
                SuccessMessage = "";
            }

            


        }
}
}
