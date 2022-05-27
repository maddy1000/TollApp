using System.Data.SqlClient;
using TestWebApp.Helpers;
using TollApp.Pages.Models;

namespace TollApp.Pages.DataAccess
{
    public class VehicleDataAccess
    {


        public string ErrorMessage { get; private set; }
        public List<VehicleDataModel> GetAll()
        {
            try
            {
                ErrorMessage = "";
                List<VehicleDataModel> vehicles = new List<VehicleDataModel>();
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "Select Id ,VehicleCategory,Cost from VEHICLE order by Id asc";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VehicleDataModel v = new VehicleDataModel();


                                v.Id = reader.GetInt32(0);
                                v.VehicleCategory = reader.GetString(1);
                                v.Cost = reader.GetInt32(2);






                                vehicles.Add(v);
                            }
                        }
                    }
                }
                return vehicles;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }






        public VehicleDataModel GetCostById(int id)

        {
            try
            {

                ErrorMessage = "";



                VehicleDataModel toll = null;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"Select Id, VehicleCategory, Cost from  vehicle where Id={id}";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                toll = new VehicleDataModel();
                                toll.Id = reader.GetInt32(0);
                                toll.VehicleCategory = reader.GetString(1);
                                toll.Cost = reader.GetInt32(2);
                              

                            }






                        }
                    }
                }
                return toll;

            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
                return null;
            }
        }


    }
}
