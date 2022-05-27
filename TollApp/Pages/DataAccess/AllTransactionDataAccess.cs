using System.Data.SqlClient;
using TestWebApp.Helpers;
using TollApp.Pages.Models;

namespace TollApp.Pages.DataAccess
{
    public class AllTransactionDataAccess
    {


        public string ErrorMessage { get; private set; }


        public List<AllTransactionDataModel> GetAllTransaction()
        {
            try
            {
                ErrorMessage = "";
                List<AllTransactionDataModel> tolls = new List<AllTransactionDataModel>();
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"select Toll.Id,User1.Id,User1.Name,TollLocation,Amount,TransactionDate from Toll inner join TOLL_TRANSACTION on Toll.Id=TOLL_TRANSACTION.TollId inner join user1 on user1.Id=TOLL_TRANSACTION.UserId  ";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AllTransactionDataModel toll = new AllTransactionDataModel();

                                toll.TollId = reader.GetInt32(0);
                                toll.UserId=reader.GetInt32(1);
                                toll.UserName = reader.GetString(2);
                                toll.TollLocation = reader.GetString(3);
                                toll.Amount = reader.GetInt32(4);
                                toll.TransactionDate = reader.GetDateTime(5);
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
