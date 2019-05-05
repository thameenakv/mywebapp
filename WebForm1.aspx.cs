using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=SAJID-RAZAK\SQLEXPRESS;Initial Catalog=Customers; Integrated Security= true;");
  

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Button2.Enabled = false;
            }
            FillGridView();
            //ds.Columns.Add("Name", typeof(string));
            //ds.Columns.Add("Mobile", typeof(string));

            //grcontact.DataSource = ds;
        }

        protected void link_OnClick(object sender, EventArgs e)
        {
            int contactID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("ContactViewByID", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@ID", contactID);
            
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            hfcontactsID.Value = contactID.ToString();
            txtname.Text = dtbl.Rows[0]["Name"].ToString();
            txtmobile.Text = dtbl.Rows[0]["Mobile"].ToString();
            Button1.Text = "Update";
            Button2.Enabled = true;
            
        }    
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            SqlCommand sqlCmd = new SqlCommand("ContactCreateOrUpdate",sqlCon);
           sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ID", (hfcontactsID.Value == "" ? 0 : Convert.ToInt32(hfcontactsID.Value)));
            sqlCmd.Parameters.AddWithValue("@Name", txtname.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Mobile", txtmobile.Text.Trim());
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            if (hfcontactsID.Value == "")
                lblsuccess.Text = "Saved Successfully";
            else
                lblsuccess.Text = "Updated Successfully";
            FillGridView();
            Clear();
            Button1.Text = "Save";
        }
        void FillGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("ContactViewAll",sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            grcontact.DataSource = dtbl;
            grcontact.DataBind();

        }

        void Clear()
        {
            txtname.Text = "";
            txtmobile.Text = "";

        }
        protected void grcontact_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            SqlCommand sqlCmd = new SqlCommand("ContactDeleteByID", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ID", (hfcontactsID.Value == "" ? 0 : Convert.ToInt32(hfcontactsID.Value)));
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
           
            lblsuccess.Text = "Deleted Successfully";
            FillGridView();
            Button1.Text = "Save";
            Clear();
        }
            
    }
}