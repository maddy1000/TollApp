using System.Data.SqlClient;
using TestWebApp.Helpers;
using TollApp.Pages.Models;

namespace TollApp.Pages.DataAccess
{
    public class TollDataAccess
    {



        public string ErrorMessage { get; set; }




        public List<TollDataModel> GetAll()
        {
            try
            {
                ErrorMessage = "";
                List<TollDataModel> tolls = new List<TollDataModel>();
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "Select * from Toll";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TollDataModel toll = new TollDataModel();

                                toll.Id = reader.GetInt32(0);
                                toll.TollLocation = reader.GetString(1);
                                toll.TollDistance = reader.GetInt32(2);
                                toll.TollPrice = reader.GetInt32(3);
                                tolls.Add(toll);
                            }
                        }
                    }
                }
                return tolls;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }





        public TollDataModel GetTollById(int id)

        {
            try
            {

                ErrorMessage = "";



                TollDataModel toll = null;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"Select Id, TollLocation, TollDistance, TollPrice from  Toll where Id={id}";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                toll = new TollDataModel();
                                toll.Id = reader.GetInt32(0);
                                toll.TollLocation = reader.GetString(1);
                                toll.TollDistance = reader.GetInt32(2);
                                toll.TollPrice = reader.GetInt32(3);

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










        public TollDataModel Insert(TollDataModel newtoll)
        {
            try
            {
                ErrorMessage = string.Empty;
                int idInserted = 0;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"INSERT INTO Toll (TollLocation,TollDistance,TollPrice) VALUES ('{newtoll.TollLocation}', {newtoll.TollDistance},{newtoll.TollPrice}); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        {
                            int numOfRows = Convert.ToInt32(cmd.ExecuteScalar());
                            if (numOfRows > 0)
                            {
                                newtoll.Id = numOfRows;
                                return newtoll;
                            }


                        }

                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }

        }










        public bool Update(TollDataModel updToll)
        {
            try
            {
                ErrorMessage = "";


                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"update Toll set TollLocation='{updToll.TollLocation}',TollDistance='{updToll.TollDistance}',TollPrice='{updToll.TollPrice}'where id={updToll.Id}";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {



                        {
                            int numOfRows = cmd.ExecuteNonQuery();
                            if (numOfRows > 0)
                            {
                                return true;
                            }



                        }

                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }






        public int Delete(int id)
        {
            try
            {
                ErrorMessage = "";


                int numOfRows = 0;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"DELETE FROM Toll Where Id = {id}";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        numOfRows = cmd.ExecuteNonQuery();
                    }
                }
                return numOfRows;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return 0;
            }








        }
    }
}
