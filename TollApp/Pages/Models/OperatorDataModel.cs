namespace TollApp.Pages.Models
{
    public class OperatorDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }




        public OperatorDataModel()
        {
            Id = 0;
            Name = "";
            MobileNumber = "";
            EmailId = "";
            Password = "";
        }


        public bool IsValid()
        {
            if (Name == null || Name.Trim().Length > 20 || Name.Trim() == "")
            {
                return false;
            }
            if (MobileNumber == null || MobileNumber.Trim().Length < 10 || MobileNumber.Trim() == "")
            {
                return false;
            }
            if (EmailId == null || EmailId.Trim().Length < 10 || EmailId.Trim() == "")
            {
                return false;
            }
            if (Password == null || Password.Trim().Length < 5 || Password.Trim() == "")
            {
                return false;
            }
            return true;

        }
    }
}
