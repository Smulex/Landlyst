using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Website
{
    public partial class Booking : Page
    {
        List<Room> listOfRooms = new List<Room>();

        SqlConnection myConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hotels;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ViewRooms_Click(object sender, EventArgs e)
        {
            rooms.Rows.Clear();
            rooms.GridLines = GridLines.Both;
            TableHeaderRow titel = new TableHeaderRow();
            TableHeaderCell roomNumberTitel = new TableHeaderCell();
            TableHeaderCell maxGuestTitel = new TableHeaderCell();
            TableHeaderCell priceTitel = new TableHeaderCell();
            TableHeaderCell featureTitel = new TableHeaderCell();
            TableHeaderCell bookbuttonTitel = new TableHeaderCell();

            roomNumberTitel.Text = "Rum nummer";
            maxGuestTitel.Text = "Plads til";
            priceTitel.Text = "Pris pr. dag";
            featureTitel.Text = "Tillægsydelser";
            bookbuttonTitel.Text = "Book fra " + Convert.ToDateTime(checkInDate.Text).ToString("dd/MM/yyyy") + " til " + Convert.ToDateTime(checkOutDate.Text).ToString("dd/MM/yyyy");

            titel.Cells.Add(roomNumberTitel);
            titel.Cells.Add(maxGuestTitel);
            titel.Cells.Add(priceTitel);
            titel.Cells.Add(featureTitel);
            titel.Cells.Add(bookbuttonTitel);

            rooms.Rows.Add(titel);

            myConnection.Open();

            string query = "SELECT Room.roomNumber, Room.maxGuest, bp.price FROM Room inner join BasePrice bp on Room.price = bp.basePriceID";

            SqlCommand selectCommand = new SqlCommand(query, myConnection);
            selectCommand.ExecuteNonQuery();
            SqlDataReader sReader;

            sReader = selectCommand.ExecuteReader();

            while (sReader.Read())
            {
                listOfRooms.Add(new Room(sReader["roomNumber"].ToString(), sReader["maxGuest"].ToString(), sReader["price"].ToString()));
            }

            myConnection.Close();

            foreach (Room room in listOfRooms)
            {
                TableRow roomRow = new TableRow();
                TableCell roomNumber = new TableCell();
                TableCell maxGuest = new TableCell();
                TableCell price = new TableCell();
                TableCell feature = new TableCell();
                TableCell bookButton = new TableCell();
                Button book = new Button();

                string[] priceAndName = GetRoomFeatures(room.RoomNumber, Convert.ToInt32(room.Price));

                roomNumber.Text = room.RoomNumber;
                maxGuest.Text = room.MaxGuest;
                price.Text = priceAndName[0];
                feature.Text = priceAndName[1];
                book.Text = "Book værelse";
                book.Click += new EventHandler(Book_Click);
                bookButton.Controls.Add(book);

                roomRow.Cells.Add(roomNumber);
                roomRow.Cells.Add(maxGuest);
                roomRow.Cells.Add(price);
                roomRow.Cells.Add(feature);
                roomRow.Cells.Add(bookButton);

                rooms.Rows.Add(roomRow);
            }

            
            //MessageBox.Show("Viser rum inde for de her datoer: " + checkInDate.Text + " - " + checkOutDate.Text);
        }

        private void Book_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Rummet er nu booket");
        }

        protected string[] GetRoomFeatures(string roomNumber, int price)
        {
            string[] priceAndName = new string[2];

            myConnection.Open();

            string query = "SELECT f.price, type FROM Feature f INNER JOIN RoomFeature rf ON f.featureID = rf.featureID INNER JOIN Room r ON rf.RoomNumber = r.RoomNumber WHERE r.RoomNumber = @roomNumber";

            SqlCommand selectCommand = new SqlCommand(query, myConnection);
            selectCommand.Parameters.AddWithValue("@roomNumber", roomNumber);
            selectCommand.ExecuteNonQuery();

            SqlDataReader sReader;

            sReader = selectCommand.ExecuteReader();

            while (sReader.Read())
            {
                if (priceAndName[1] != null)
                {
                    priceAndName[1] += ", ";
                }
                priceAndName[1] += (sReader["type"].ToString());

                price += Convert.ToInt32(sReader["price"].ToString());
            }

            myConnection.Close();

            priceAndName[0] = Convert.ToString(price);

            return priceAndName;
        }
        //string query = "Insert into [dbo].[UserAccount] (Name,Address) Values (@name,@add)";

        //SqlCommand insertCommand = new SqlCommand(query, myConnection);
        //insertCommand.Parameters.AddWithValue("@name", TextBox1.Text);
        //insertCommand.Parameters.AddWithValue("@add", TextBox2.Text);
        //insertCommand.ExecuteNonQuery();
    }

    public class Room
    {
        public string RoomNumber { get; set; }
        public string MaxGuest { get; set; }
        public string Price { get; set; }
        public string Features { get; set; }

        public Room(string roomNumber, string maxGuest, string price)
        {
            RoomNumber = roomNumber;
            MaxGuest = maxGuest;
            Price = price;
        }
    }
}