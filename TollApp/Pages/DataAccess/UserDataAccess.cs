using System.Data.SqlClient;
using TestWebApp.Helpers;
using TollApp.Pages.Models;

namespace TollApp.Pages.DataAccess
{
    public class UserDataAccess
    {

        public string ErrorMessage { get; private set; }
        public List<UserDataModel> GetAll()
        {
            try
            {
                ErrorMessage = "";
                List<UserDataModel> users = new List<UserDataModel>();
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "Select * from user1";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserDataModel user= new UserDataModel();

                                user.Id = reader.GetInt32(0);
                                user.Name = reader.GetString(1);
                                user.MobileNumber = reader.GetString(2);
                                user.EmailId = reader.GetString(3);
                                user.Password=reader.GetString(4);
                                user.CreatedAt= reader.GetDateTime(5);
                                user.VehicleCategoryId = reader.GetInt32(6);
                                user.VehicleNumber = reader.GetString(7);
                                user.BalanceAmount = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);

                                users.Add(user);
                            }
                        }
                    }
                }
                return users;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }



        public UserDataModel GetUserByMAil(string UserName, string Password)
        {
            try
            {
                ErrorMessage = "";

             
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"Select * from  user1 where EmailId = '{UserName}' and Password= '{Password}'";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                UserDataModel user = new UserDataModel();

                                user.Id = reader.GetInt32(0);
                                user.Name = reader.GetString(1);
                                user.MobileNumber = reader.GetString(2);
                                user.EmailId = reader.GetString(3);
                                user.Password = reader.GetString(4);
                                user.CreatedAt = reader.GetDateTime(5);
                                user.VehicleCategoryId = reader.GetInt32(6);
                                user.VehicleNumber = reader.GetString(7);
                                user.BalanceAmount = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);

                                return user;


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



        public UserDataModel GetUserById(int id)

        {
            try
            {

                ErrorMessage = "";

                UserDataModel user = null;

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"Select Id, Name,MobileNumber,EmailId,Password,CreatedAt,VehicleCategoryId, VehicleNumber,BalanceAmount from  User1 where Id={id}";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new UserDataModel();
                                user.Id = reader.GetInt32(0);
                                user.Name = reader.GetString(1);
                                user.MobileNumber = reader.GetString(2);
                                user.EmailId = reader.GetString(3);
                                user.Password = reader.GetString(4);
                                user.CreatedAt = reader.GetDateTime(5);
                                user.VehicleCategoryId = reader.GetInt32(6);
                                user.VehicleNumber = reader.GetString(7);
                                user.BalanceAmount = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);



                            }
                        }
                    }
                }
                return user;

            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
                return null;
            }
        }



        public bool Insert(UserDataModel newuser)
        {
            try
            {
                ErrorMessage = string.Empty;
                int idInserted = 0;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"INSERT INTO dbo.user1 (Name,MobileNumber,EmailId,Password,VehicleCategoryId,VehicleNumber) VALUES ('{newuser.Name}', '{newuser.MobileNumber}','{newuser.EmailId}','{newuser.Password}',{newuser.VehicleCategoryId},'{newuser.VehicleNumber}'); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        idInserted = Convert.ToInt32(cmd.ExecuteScalar());
                        if (idInserted > 0)
                        {
                            return true;
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



        public bool Update(UserDataModel updUser)
        {
            try
            {
                ErrorMessage = "";


                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"update User1 set Name='{updUser.Name}',VehicleNumber='{updUser.VehicleNumber}',MobileNumber='{updUser.MobileNumber}',EmailId='{updUser.EmailId}',VehicleCategoryId={updUser.VehicleCategoryId} where id={updUser.Id}";
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
                    string sqlStmt = $"DELETE FROM User1 Where Id = {id}";

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







        public int GetBalanceById(int id)
        {
            try
            {

                ErrorMessage = "";



                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"select BalanceAmount from user1 where id ={id} ";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        var cost = Convert.ToInt32(cmd.ExecuteScalar());
                        return cost;
                    }

                }



            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return 0;

        }





        public bool UpdateAmount(UserDataModel  newuser, int id)
        {
            try
            {
                ErrorMessage = string.Empty;
                int idInserted = 0;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"update  dbo.user1 set BalanceAmount=isnull(BalanceAmount,0)+{newuser.BalanceAmount} where Id={id}; SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int numOfRows = cmd.ExecuteNonQuery();
                        if (numOfRows > 0)
                        {
                            return true;
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







    }
}
