using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using TollApp.Pages.DataAccess;

namespace TollApp.Pages
{
    public class LoginOpModel : PageModel
    {

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public LoginOpModel()
        {
            UserName = "";
            Password = "";
            ErrorMessage = "";
        }
        public void OnGet()
        {
        }

        public async void OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Login or Password";
                return;
            }

            //check admin
            if (UserName == "admin" && Password == "12345")
            {
                var userClaims = new List<Claim>()
                {
                    new Claim ("UserId", "0"),
                    new Claim (ClaimTypes.Name, "Admininistrator"),
                    new Claim (ClaimTypes.Role, "Admin")
                };

                var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                await HttpContext.SignInAsync(userPrincipal);


                Response.Redirect("/AdminDashboard");
                return;
            }

           
            var operatorDataAccess = new OperatorDataAccess();
            var op = operatorDataAccess.GetOperatorByMAil(UserName, Password);

            if (op != null)
            {
                var userClaims = new List<Claim>()
                {
                    new Claim("UserId",op.Id.ToString()),
                    new Claim(ClaimTypes.Name,op.Name),
                    new Claim(ClaimTypes.Email,op.EmailId),
                    new Claim(ClaimTypes.Role,"Operator")
                };
                var userIdentity = new ClaimsIdentity(userClaims, "user Identity");
                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });

                await HttpContext.SignInAsync(userPrincipal);
                HttpContext.Session.SetInt32("UserId", op.Id);
                HttpContext.Session.SetString("UserName", op.Name);
                //HttpContext.Session.SetInt32("VehicleId", user.VehicleCategoryId);
                //HttpContext.Session.SetInt32("Balance", 0);
                Response.Redirect("/Index");
                return;
            }
            ErrorMessage = "Invalid Login or Password";
        }



    }
}
