namespace TollApp.Pages.Models
{
    public class UserDataModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }

        public string EmailId { get; set; }
       public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public int VehicleCategoryId { get; set; }

        public string VehicleNumber { get; set; }
         public int BalanceAmount { get; set; }




        public UserDataModel()
        {
            
            Name = "";
            EmailId = "";
            Password = "";
            CreatedAt = DateTime.Now;
            VehicleCategoryId = 0;
            VehicleNumber = "";
            BalanceAmount = 0;

        }

        public bool IsValid()
        {
          

            if (Name == null || Name.Trim().Length > 20 || Name.Trim() == "")
            {
                return false;
            }
            if (EmailId == null || EmailId.Trim().Length > 30 || EmailId.Trim() == "")
            {
                return false;
            }
            if(Password == null )
            {
                return false;
            }
            if(VehicleNumber==null || VehicleNumber.Trim().Length > 30 || VehicleNumber.Trim() == "")
            {
                return false;
            }
          
            return true;
        }

    }
}
