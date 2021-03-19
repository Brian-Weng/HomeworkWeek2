using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace HomeWorkWeek2
{
    public class DataBaseExecutor
    {
        public static void InsertTable(string Num, string date, string Amt, string R_E)
        {
            string connectionString = "Data source=localhost\\SQLExpress;Initial Catalog=Financials; Integrated Security=true";
            string queryString =
                $@"INSERT INTO BusinessTax
                    (invoiceNumber, invoiceDate, invoiceAmount, Reven_Expen)
                   VALUES
                    (@invoiceNumber, @invoiceDate, @invoiceAmount, @Reven_Expen)
                    ";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@invoiceNumber", Num);
                command.Parameters.AddWithValue("@invoiceDate", date);
                command.Parameters.AddWithValue("@invoiceAmount", Amt);
                command.Parameters.AddWithValue("@Reven_Expen", R_E);
                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    HttpContext.Current.Response.Write(ex);
                }
            }
        }

        public static void DeleteTable(string Num)
        {
            string connectionString = "Data source=localhost\\SQLExpress;Initial Catalog=Financials; Integrated Security=true";
            string queryString =
                $@"DELETE FROM BusinessTax
                   WHERE invoiceNumber = @invoiceNumber";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@invoiceNumber", Num);

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

        public static void UpdateTable(string Num, string date, string Amt, string R_E)
        {
            string connectionString = "Data source=localhost\\SQLExpress;Initial Catalog=Financials; Integrated Security=true";
            string queryString =
                $@"UPDATE BusinessTax
                   SET invoiceDate = @invoiceDate, invoiceAmount = @invoiceAmount,
                       Reven_Expen = @Reven_Expen
                   WHERE invoiceNumber = @invoiceNumber";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@invoiceNumber", Num);
                command.Parameters.AddWithValue("@invoiceDate", date);
                command.Parameters.AddWithValue("@invoiceAmount", Amt);
                command.Parameters.AddWithValue("@Reven_Expen", R_E);
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

        public static DataTable SearchTable(string Num)
        {
            string connectionString = "Data source=localhost\\SQLExpress;Initial Catalog=Financials; Integrated Security=true";
            string queryString =
                $@"SELECT invoiceNumber, invoiceDate, invoiceAmount, Reven_Expen
                   FROM BusinessTax
                   WHERE invoiceNumber = @invoiceNumber
                    ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@invoiceNumber", Num);
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
                $@"SELECT * FROM BusinessTax
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