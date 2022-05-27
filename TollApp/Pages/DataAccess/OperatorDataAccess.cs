using System.Data.SqlClient;
using TestWebApp.Helpers;
using TollApp.Pages.Models;

namespace TollApp.Pages.DataAccess
{
    public class OperatorDataAccess
    {



        public string ErrorMessage { get; private set; }





        public List<OperatorDataModel> GetAll()
        {
            try
            {
                ErrorMessage = "";
                List<OperatorDataModel> operators = new List<OperatorDataModel>();
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "Select * from operator";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                OperatorDataModel op = new OperatorDataModel();

                                op.Id = reader.GetInt32(0);
                                op.Name = reader.GetString(1);
                                op.MobileNumber = reader.GetString(2);
                                op.EmailId = reader.GetString(3);
                                op.Password = reader.GetString(4);


                                operators.Add(op);
                            }
                        }
                    }
                }
                return operators;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }





        public OperatorDataModel GetOperatorById(int id)

        {
            try
            {

                ErrorMessage = "";

                OperatorDataModel user = null;

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"Select Id, Name,MobileNumber,EmailId from  operator where Id={id}";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new OperatorDataModel();
                                user.Id = reader.GetInt32(0);
                                user.Name = reader.GetString(1);
                                user.MobileNumber = reader.GetString(2);
                                user.EmailId = reader.GetString(3);




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






        public OperatorDataModel GetOperatorByMAil(string UserName, string Password)
        {
            try
            {
                ErrorMessage = "";


                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"Select * from  Operator where EmailId = '{UserName}' and Password= '{Password}'";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                OperatorDataModel op = new OperatorDataModel();

                                op.Id = reader.GetInt32(0);
                                op.Name = reader.GetString(1);
                                op.MobileNumber = reader.GetString(2);
                                op.EmailId = reader.GetString(3);
                                op.Password = reader.GetString(4);
                             

                                return op;


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







            public OperatorDataModel Insert(OperatorDataModel newoperator)
        {
            try
            {
                ErrorMessage = string.Empty;
                int idInserted = 0;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"INSERT INTO OPERATOR (Name,MobileNumber,EmailId,Password) VALUES ('{newoperator.Name}', '{newoperator.MobileNumber}','{newoperator.EmailId}','{newoperator.Password}'); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        {
                            int numOfRows = Convert.ToInt32(cmd.ExecuteScalar());
                            if (numOfRows > 0)
                            {
                                newoperator.Id = numOfRows;
                                return newoperator;
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




        public bool Update(OperatorDataModel updOperator)
        {
            try
            {
                ErrorMessage = "";


                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"update Operator set Name='{updOperator.Name}',MobileNumber='{updOperator.MobileNumber}',EmailId='{updOperator.EmailId}' where Id={updOperator.Id}";
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
                    string sqlStmt = $"DELETE FROM Operator Where Id = {id}";

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
