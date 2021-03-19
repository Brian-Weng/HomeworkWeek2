using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HomeWorkWeek2
{
    public class Executor_2
    {
        public static void InsertTable(string Date, string Acnt, string Sum, string Rec, string Pay)
        {
            string connectionString = "Data source=localhost\\SQLExpress;Initial Catalog=Financials; Integrated Security=true";
            string queryString =
                $@"INSERT INTO CashJournal
                    (CashDate, Account, Summary, Revenue, Expence)
                   VALUES
                    (@CashDate, @Account, @Summary, @Revenue, @Expence)
                    ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@CashDate", Date);
                command.Parameters.AddWithValue("@Account", Acnt);
                command.Parameters.AddWithValue("@Summary", Sum);
                command.Parameters.AddWithValue("@Revenue", Rec);
                command.Parameters.AddWithValue("@Expence", Pay);
                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write(ex);
                }
            }
        }


        public static void UpdateTable(string ID, string Date, string Acnt, string Sum, string Rec, string Pay)
        {
            string connectionString = "Data source=localhost\\SQLExpress;Initial Catalog=Financials; Integrated Security=true";
            string queryString =
                $@"UPDATE CashJournal
                   SET CashDate = @CashDate, Account = @Account,
                       Summary = @Summary, Revenue = @Revenue, Expence = @Expence
                   WHERE ID = @ID"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@CashDate", Date);
                command.Parameters.AddWithValue("@Account", Acnt);
                command.Parameters.AddWithValue("@Summary", Sum);
                command.Parameters.AddWithValue("@Revenue", Rec);
                command.Parameters.AddWithValue("@Expence", Pay);
                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write(ex);
                }
            }
        }

        public static DataTable SearchTable(string Date)
        {
            string connectionString = "Data source=localhost\\SQLExpress;Initial Catalog=Financials; Integrated Security=true";
            string queryString =
                $@"SELECT * FROM CashJournal
                   WHERE CashDate = @CashDate
                    ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@CashDate", Date);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write(ex);
                    return null;
                }
            }
        }

        public static DataTable ShowAllTable()
        {
            string connectionString = "Data source=localhost\\SQLExpress;Initial Catalog=Financials; Integrated Security=true";
            string queryString =
                $@"SELECT * FROM CashJournal
                    ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write(ex);
                    return null;
                }
            }
        }
    }
}