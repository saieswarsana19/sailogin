using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace sailogin
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1181R47\\SQLEXPRESS;Initial Catalog=sai;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindgrid();
            }

        }
        protected void bindgrid()
        {
            SqlCommand cmd = new SqlCommand("select*from login", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            GridView.DataSource = dr;
            GridView.DataBind();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into login(username,password)values(@username,@password)", conn);
            cmd.Parameters.AddWithValue("@username",txtuname.Text);
            cmd.Parameters.AddWithValue("@password",txtpassword.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            bindgrid();
        }

        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userid = Convert.ToInt32(GridView.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand("delete from login where userid=@userid", conn);
            cmd.Parameters.AddWithValue("@userid", userid);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            bindgrid();
        }
        protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GridView.Rows[e.NewEditIndex];
            ViewState["userid"] = GridView.DataKeys[e.NewEditIndex].Value;
            txtuname.Text = row.Cells[2].Text;
            txtpassword.Text = row.Cells[3].Text;
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update login set username=@username,password=@password where userid=@userid",conn);
            cmd.Parameters.AddWithValue("@userid", ViewState["userid"]);
            cmd.Parameters.AddWithValue("@username",txtuname.Text);
            cmd.Parameters.AddWithValue("@password",txtpassword.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            bindgrid();
        }
    }
}