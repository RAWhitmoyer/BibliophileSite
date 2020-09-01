using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;




public partial class Webpages_CustomerDisplay_CustomerDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSelect(object sender, EventArgs e)
    {
        String connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\TechSupport.mdf;Integrated Security=True";
        SqlConnection conn = new SqlConnection(connString);
        int id = int.Parse(ddlCustomers.SelectedValue);

        string queryAddress = "SELECT Address FROM [dbo].[Customers] WHERE CustomerID = " + "'" + id + "'";
        SqlCommand commandAddress = new SqlCommand(queryAddress, conn);
        string addr = "";

        string queryPhone = "SELECT Phone  FROM [dbo].[Customers] WHERE CustomerID = " + "'" + id + "'";
        SqlCommand commandPhone = new SqlCommand(queryPhone, conn);
        string phone = "";

        string queryEmail = "SELECT Email FROM [dbo].[Customers] WHERE CustomerID = " + "'" + id + "'";
        SqlCommand commandEmail = new SqlCommand(queryEmail, conn);
        string email = "";

        string queryCity = "SELECT City from [dbo].[Customers] WHERE CustomerID = " + "'" + id + "'";
        SqlCommand commandCity = new SqlCommand(queryCity, conn);
        string city = "";

        string queryState = "SELECT State from [dbo].[Customers] WHERE CustomerID = " + "'" + id + "'";
        SqlCommand commandState = new SqlCommand(queryState, conn);
        string state = "";

        string queryZip = "SELECT ZipCode from [dbo].[Customers] WHERE CustomerID = " + "'" + id + "'";
        SqlCommand commandZip = new SqlCommand(queryZip, conn);
        string zip = "";

        SqlDataReader reader;


        conn.Open();

        reader = commandAddress.ExecuteReader();
        while (reader.Read())
        {
            addr += reader.GetValue(0);
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

        reader = commandCity.ExecuteReader();
        while (reader.Read())
        {
            city += reader.GetValue(0);
        }
        reader.Close();

        reader = commandState.ExecuteReader();
        while (reader.Read())
        {
            state += reader.GetValue(0);
        }
        reader.Close();

        reader = commandZip.ExecuteReader();
        while (reader.Read())
        {
            zip += reader.GetValue(0);
        }
        reader.Close();

        conn.Close();

        lblAddress.ForeColor = System.Drawing.Color.Black;
        lblEmail.ForeColor = System.Drawing.Color.Black;
        lblPhone.ForeColor = System.Drawing.Color.Black;
        lblCityStateZip.ForeColor = System.Drawing.Color.Black;

        

        lblAddress.Text = addr;
        lblCityStateZip.Text = city + ", " + state + " " + zip;
        lblEmail.Text = email;
        lblPhone.Text = phone;
    }
}