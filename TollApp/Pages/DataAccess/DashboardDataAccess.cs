using System.Data.SqlClient;
using TestWebApp.Helpers;
using TollApp.Pages.Models;

namespace TollApp.Pages.DataAccess
{
    public class DashboardDataAccess
    {

        public string ErrorMessage { get; set; }

        public DashboardDataAccess()
        {
            ErrorMessage = "";
        }

        public DashboardDataModel GetAll()
        {
            try
            {

                var db = new DashboardDataModel();
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "select count(*) as UserCount from user1; select scope_identity()";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))

                    {
                        db.UserCount = Convert.ToInt32(cmd.ExecuteScalar());


                    }
                    sqlStmt = "select count(*) as OperatorCount from operator";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        db.OperatorCount = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    sqlStmt = "select count(*) as TollCount from Toll";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        db.TollCount = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                }





                return db;


            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }


    }
}
