using System.Data.SqlClient;
using TestWebApp.Helpers;
using TollApp.Pages.Models;

namespace TollApp.Pages.DataAccess
{
    public class UserTransactionDataAccess
    {


        public string ErrorMessage { get; private set; }


        public List<UserDataViewModel> GetAllTransaction()
        {
            try
            {
                ErrorMessage = "";
                List<UserDataViewModel> tolls = new List<UserDataViewModel>();
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"select Toll.Id,TollLocation,Amount,TransactionDate from Toll inner join TOLL_TRANSACTION on Toll.Id=TOLL_TRANSACTION.TollId  ";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserDataViewModel toll = new UserDataViewModel();

                                toll.Id = reader.GetInt32(0);
                                toll.TollLocation=reader.GetString(1);
                                toll.Amount = reader.GetInt32(2);
                                toll.TransactionDate=reader.GetDateTime(3);
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



        public bool Insert(TollTransactionModel newtrip)
        {
            try
            {
                ErrorMessage = string.Empty;
                int idInserted = 0;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"Update dbo.User1 Set BalanceAmount = ISNULL(BalanceAmount,0) - {newtrip.Amount};" +
                                   $"INSERT INTO dbo.Toll_Transaction (Amount,UserId,TollId) VALUES ({newtrip.Amount}, {newtrip.UserId},{newtrip.TollId}); SELECT SCOPE_IDENTITY();";

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
                this.ErrorMessage = ex.Message;
                return false;
            }



        }


            public List<UserDataViewModel> GetUser(int id)
            {
                try
                {
                    ErrorMessage = "";
                    List<UserDataViewModel> tolls = new List<UserDataViewModel>();
                    using (SqlConnection conn = Database.GetConnection())
                    {
                        conn.Open();
                        var sqlStmt = $"select Toll.Id as TollId,TollLocation,Amount,TransactionDate from Toll inner join TOLL_TRANSACTION on Toll.Id=TOLL_TRANSACTION.TollId where TOLL_TRANSACTION.UserId={id} ";
                        using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    UserDataViewModel toll = new UserDataViewModel();

                                    toll.Id = reader.GetInt32(0);
                                    toll.TollLocation = reader.GetString(1);
                                    toll.Amount = reader.GetInt32(2);
                                    toll.TransactionDate = reader.GetDateTime(3);
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


        }



    }



