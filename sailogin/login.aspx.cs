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

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into login(username,password)values(@username,@password)", conn);
            cmd.Parameters.AddWithValue("@username",txtuname.Text);
            cmd.Parameters.AddWithValue("@password",txtpassword.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}