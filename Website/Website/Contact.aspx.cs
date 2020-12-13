using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class Contact : Page
    {
        SqlConnection myConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hotels;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            address.Text = GetAddress("Landlyst");
            phoneNumber.Text = GetPhoneNumber("Landlyst");
            mail.Text = GetMail("Landlyst");
            mailLink.NavigateUrl = "mailto:" + mail.Text;
        }
        protected string GetPhoneNumber(string name)
        {
            string s = string.Empty;

            myConnection.Open();

            string query = "Select phoneNumber FROM hotel WHERE name = @hotelName;";

            SqlCommand selectCommand = new SqlCommand(query, myConnection);
            selectCommand.Parameters.AddWithValue("@hotelName", name);
            selectCommand.ExecuteNonQuery();
            SqlDataReader sReader;

            sReader = selectCommand.ExecuteReader();

            while (sReader.Read())
            {
                s = sReader["phoneNumber"].ToString();
            }

            myConnection.Close();

            return s;
        }
        protected string GetAddress(string name)
        {
            string s = string.Empty;

            myConnection.Open();

            string query = "Select streetAddress, h.zipCode, city FROM hotel h inner join Zip z on h.zipCode = z.zipCode Where name = @hotelName;";

            SqlCommand selectCommand = new SqlCommand(query, myConnection);
            selectCommand.Parameters.AddWithValue("@hotelName", name);
            selectCommand.ExecuteNonQuery();
            SqlDataReader sReader;

            sReader = selectCommand.ExecuteReader();

            while (sReader.Read())
            {
                s = sReader["streetAddress"].ToString() + ", " + sReader["zipCode"].ToString() + " " + sReader["city"].ToString();
            }

            myConnection.Close();

            return s;
        }
        protected string GetMail(string name)
        {
            string s = string.Empty;

            myConnection.Open();

            string query = "Select emailAddress FROM hotel Where name = @hotelName;";

            SqlCommand selectCommand = new SqlCommand(query, myConnection);
            selectCommand.Parameters.AddWithValue("@hotelName", name);
            selectCommand.ExecuteNonQuery();
            SqlDataReader sReader;

            sReader = selectCommand.ExecuteReader();

            while (sReader.Read())
            {
                s = sReader["emailAddress"].ToString();
            }

            myConnection.Close();

            return s;
        }
    }
}