using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using TollApp.Pages.DataAccess;

namespace TollApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public LoginModel()
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


            //if (UserName == "admin" && Password == "12345")
            //{
            //    var userClaims = new List<Claim>()
            //    {
            //        new Claim ("UserId", "0"),
            //        new Claim (ClaimTypes.Name, "Admininistrator"),
            //        new Claim (ClaimTypes.Role, "Admin")
            //    };

            //    var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

            //    var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
            //    await HttpContext.SignInAsync(userPrincipal);


            //    Response.Redirect("/AdminDashboard");
            //    return;
            //}


            //Check User
            var userDataAccess = new UserDataAccess();
            var user = userDataAccess.GetUserByMAil(UserName, Password);

            if (user != null)
            {
                var userClaims = new List<Claim>()
                {
                    new Claim("UserId",user.Id.ToString()),
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.Name),
                    new Claim(ClaimTypes.Email,user.EmailId),
                    new Claim(ClaimTypes.Role,"User")
                };
                var userIdentity = new ClaimsIdentity(userClaims, "user Identity");
                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                //userIdentity.Name = user.Id.ToString();
                

                await HttpContext.SignInAsync(userPrincipal);
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("UserName", user.Name);
                HttpContext.Session.SetInt32("VehicleId", user.VehicleCategoryId);
                HttpContext.Session.SetInt32("Balance", 0);
                Response.Redirect("/Index");
                return;
            }

           
            ErrorMessage = "Invalid Login or Password";
        }



        


  
        }
    }

