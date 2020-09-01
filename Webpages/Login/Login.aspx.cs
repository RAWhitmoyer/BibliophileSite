using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;



    public partial class Webpages_Login_Login : System.Web.UI.Page
    {

        private string ConnectionString;
        private SqlConnection conn;
        string username;


        protected void Page_Load(object sender, EventArgs e)
        {
            ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";
            conn = new SqlConnection(ConnectionString);


        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
        //note if multiple accounts have the same username login is not guaranteed
            
            if (!uname2.Text.Equals("") && !pwd2.Text.Equals(""))
            {
                lbl2.Text = "";


                conn.Open();

                string sqlQuery = "SELECT Password FROM [dbo].[LoginTable] WHERE Username = ";
                sqlQuery += "'" + uname2.Text + "'";
                //executes command and reads the output, storing hashed value into string
                SqlDataReader reader;
                string output = "";
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    output += reader.GetValue(0);
                }

                conn.Close();
                if (output.Length > 0)
                {
                    //converting the stored password hash into a byte array
                    byte[] hashBytes = Convert.FromBase64String(output);
                    //getting the salt from the first 16 indices
                    byte[] salt = new byte[16];
                    Array.Copy(hashBytes, 0, salt, 0, 16);
                    //we now have the salt from when the password was hashed

                    //debug
                    //string test = Convert.ToBase64String(salt);
                    //^^debug

                    //now hash the input password and compare
                    string inputPW = pwd2.Text;
                    var pbkdf2 = new Rfc2898DeriveBytes(inputPW, salt, 100);

                    byte[] inputHash = pbkdf2.GetBytes(20);
                    //byte[] storedHash = new byte[20];
                    //Array.Copy(hashBytes, 16, storedHash, 0, 20);

                    Boolean match = true;
                    for (int i = 0; i < 20; i++)
                    {
                        Byte b1 = inputHash[i];
                        Byte b2 = hashBytes[i + 16];
                        Boolean comp = b1.Equals(b2);
                        if (!(comp))
                        {
                            match = false;
                        }
                    }




                    if (match)
                    {
                        lbl2.Text = "Log in was successful";
                        username = uname2.Text;

                        Session["username"] = uname2.Text;
                        Response.Redirect("/Webpages/UserPage/UserPage.aspx");
                        //Server.Transfer("/Webpages/UserPage/UserPage.aspx", true);
                    }
                    else
                    {
                        lbl2.Text = "Username and Password do not match";
                    }
                    lbl2.ForeColor = System.Drawing.Color.Black;

                    uname2.Text = "";
                    pwd2.Text = "";


                }
                else
                {
                    lbl2.ForeColor = System.Drawing.Color.Black;
                    lbl2.Text = "Username not found";
                }
            }
            else
            {
                lbl2.ForeColor = System.Drawing.Color.Black;
                lbl2.Text = "Please enter username and password";
            }

        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
        
            if (!uname.Text.Equals("") && !pwd.Text.Equals("") && !phone.Text.Equals("") && !email.Text.Equals(""))
            {

                conn.Open();

                Random rand = new Random();
                //can theoretically generate duplicates but unlikely insert try catch for this at some point
                int id = rand.Next(99999);

                //note the salting and hashing for both functions was inspired by https://medium.com/@mehanix/lets-talk-security-salted-password-hashing-in-c-5460be5c3aae
                //stores salt for password hash
                byte[] PWsalt;
                //generates the salt
                new RNGCryptoServiceProvider().GetBytes(PWsalt = new byte[16]);
                //gets user input password

                //debug
                //string test = Convert.ToBase64String(PWsalt);
                //^^debug

                string password = pwd.Text;
                //hash and salt using pbkdf2, a hashing algorithm
                var pbkdf2 = new Rfc2898DeriveBytes(password, PWsalt, 100);

                //place what we jsut hashed into a byte array
                byte[] hash = pbkdf2.GetBytes(20);
                //new byte array to store hash plus salt
                //36 for the 20 hash bytes and 16 salt bytes
                byte[] hashBytes = new byte[36];
                Array.Copy(PWsalt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);
                //put the hashed password plus salt into a string to put in DB
                string hashedPW = Convert.ToBase64String(hashBytes);



                //this is bad practice and could lead to SQLinjections, but it was the first/easiest solution I found
                string sqlQuery = "INSERT INTO [dbo].[LoginTable] ([Id], [Username], [Password], [Phone], [Email]) VALUES (";
                sqlQuery += id;
                sqlQuery += ", ";
                sqlQuery += "N'" + uname.Text + "', ";
                sqlQuery += "N'" + hashedPW + "', ";
                sqlQuery += "N'" + phone.Text + "', ";
                sqlQuery += "N'" + email.Text + "')";

                //Console.WriteLine(sqlQuery);

                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.ExecuteNonQuery();
                conn.Close();
                uname.Text = "";
                pwd.Text = "";
                phone.Text = "";
                email.Text = "";
                lbl.Text = "Created Successfully";
                lbl.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                lbl.Text = "Not all fields are filled";
                lbl.ForeColor = System.Drawing.Color.Black;
            }



        }
    }
