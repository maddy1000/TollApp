namespace TollApp.Pages.Models
{
    public class VehicleDataModel
    {
        public int Id { get; set; }
        public string VehicleCategory { get; set; }

        public int Cost { get; set; }






        public VehicleDataModel()
        {
            VehicleCategory = "";
            Cost = 0;

        }
    }

}