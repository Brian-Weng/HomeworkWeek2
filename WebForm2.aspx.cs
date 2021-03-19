using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace HomeWorkWeek2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ListC_Jnal.DataSource = Executor_2.ShowAllTable();
                ListC_Jnal.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cDate = this.cashDate.Text;
            string cAcnt = this.account.Text;
            string cSum = this.summary.Text;
            string cRec = this.receive.Text;
            string cPay = this.pay.Text;
            Executor_2.InsertTable(cDate, cAcnt, cSum, cRec, cPay);

            ListC_Jnal.DataSource = Executor_2.ShowAllTable();
            ListC_Jnal.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string ID = this.ID.Text;
            string cDate = this.cashDate.Text;
            string cAcnt = this.account.Text;
            string cSum = this.summary.Text;
            string cRec = this.receive.Text;
            string cPay = this.pay.Text;
            Executor_2.UpdateTable(ID, cDate, cAcnt, cSum, cRec, cPay);

            ListC_Jnal.DataSource = Executor_2.ShowAllTable();
            ListC_Jnal.DataBind();
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            string cDate = this.cashDate.Text;

            ListC_Jnal.DataSource = Executor_2.SearchTable(cDate);
            ListC_Jnal.DataBind();
        }

        protected void ListC_Jnal_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ID = ListC_Jnal.DataKeys[e.RowIndex].Value.ToString();

            string connectionString = "Data source=localhost\\SQLExpress;Initial Catalog=Financials; Integrated Security=true";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($@"DELETE FROM CashJournal WHERE ID = {ID}", connection);
                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write(ex);
                }

                ListC_Jnal.DataSource = Executor_2.ShowAllTable();
                ListC_Jnal.DataBind();
            }
        }

    }
}