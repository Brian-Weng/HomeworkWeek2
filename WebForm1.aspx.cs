using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace HomeWorkWeek2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                ListB_Tax.DataSource = DataBaseExecutor.ShowAllTable();
                ListB_Tax.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string inNum = this.txtinNum.Text;
            string inDate = this.txtinDate.Text;
            string inAmt = this.txtinAmt.Text;
            string inE_R = this.drpE_R.Text;
            DataBaseExecutor.InsertTable(inNum, inDate, inAmt, inE_R);
            
            //DataTable dt = new DataTable();
            //dt.Columns.Add("invoiceNumber");
            //dt.Columns.Add("invoiceDate");
            //dt.Columns.Add("invoiceAmount");
            //dt.Columns.Add("Reven_Expen");

            //DataRow dw1 = dt.NewRow();
            //dw1["invoiceNumber"] = txtinAmt.Text;
            //dw1["invoiceDate"] = txtinDate.Text;
            //dw1["invoiceAmount"] = txtinAmt.Text;
            //dw1["Reven_Expen"] = drpE_R.Text;

            //dt.Rows.Add(dw1);
 
            ListB_Tax.DataSource = DataBaseExecutor.ShowAllTable(); 
            ListB_Tax.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string inNum = this.txtinNum.Text;
            
            DataBaseExecutor.DeleteTable(inNum); 
           
            ListB_Tax.DataSource = DataBaseExecutor.ShowAllTable();
            ListB_Tax.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string inNum = this.txtinNum.Text;
            string inDate = this.txtinDate.Text;
            string inAmt = this.txtinAmt.Text;
            string inE_R = this.drpE_R.Text;
            DataBaseExecutor.UpdateTable(inNum, inDate, inAmt, inE_R);

            ListB_Tax.DataSource = DataBaseExecutor.ShowAllTable();
            ListB_Tax.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string inNum = this.txtinNum.Text;
            ListB_Tax.DataSource = DataBaseExecutor.SearchTable(inNum);//不同於增刪修,查詢須回傳datatable並讓gridview直接做連接,才不會又重抓一次SQL Sever中的資料
            ListB_Tax.DataBind();
        }
    }
}