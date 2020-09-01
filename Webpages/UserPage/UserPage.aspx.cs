using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;



public partial class Webpages_UserPage_UserPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //gets data from previous page
        name.Text = Session["username"].ToString();
    }

    protected void BtnUserSelect(object sender, EventArgs e)
    {
        String ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";
        SqlConnection connection = new SqlConnection(ConnectionString);
        int id = int.Parse(ddlUsers.SelectedValue);

        

        string queryPhone = "SELECT Phone  FROM [dbo].[LoginTable] WHERE Id = " + "'" + id + "'";
        SqlCommand commandPhone = new SqlCommand(queryPhone, connection);
        string phone = "";

        string queryEmail = "SELECT Email FROM [dbo].[LoginTable] WHERE Id = " + "'" + id + "'";
        SqlCommand commandEmail = new SqlCommand(queryEmail, connection);
        string email = "";

        string queryUsername = "SELECT Username FROM [dbo].[LoginTable] WHERE Id = " + "'" + id + "'";
        SqlCommand commandUsername = new SqlCommand(queryUsername, connection);
        string username = "";

        SqlDataReader reader;
        connection.Open();

        reader = commandUsername.ExecuteReader();
        while (reader.Read())
        {
            username += reader.GetValue(0);
        }
        reader.Close();

        reader = commandPhone.ExecuteReader();
        while (reader.Read())
        {
            phone += reader.GetValue(0);
        }
        reader.Close();

        reader = commandEmail.ExecuteReader();
        while (reader.Read())
        {
            email += reader.GetValue(0);
        }
        reader.Close();
        connection.Close();

        lblUname.ForeColor = System.Drawing.Color.Black;
        lblUemail.ForeColor = System.Drawing.Color.Black;
        lblUphone.ForeColor = System.Drawing.Color.Black;

        lblUname.Text = username;
        lblUemail.Text = email;
        lblUphone.Text = phone;


    }

}

