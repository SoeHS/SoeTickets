using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace UTTicketReservationbyKaungMinKhant
{
    class dbConnection
    {
       
       
       public void selection(String database_name, DataGridView dgv)
        {

            String connString = "Data Source=127.0.0.1;" + "Initial Catalog=movie_ticket_reservation_system;" + "User id=root;" + "Password='';";
            MySqlConnection connc = new MySqlConnection(connString);
            String CommandText = "SELECT * FROM " + database_name;
            MySqlCommand command = new MySqlCommand(CommandText, connc);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bs = new BindingSource();
                bs.DataSource = dbdataset;
                dgv.DataSource = bs;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void insert(String commandText)
        {
            try
            {
                String connString = "Data Source=127.0.0.1;" + "Initial Catalog=movie_ticket_reservation_system;" + "User id=root;" + "Password='';";

               
                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand command = new MySqlCommand(commandText, conn);
                MySqlDataReader reader;
                conn.Open();
                reader = command.ExecuteReader();
                MessageBox.Show("Data Saved");
                while (reader.Read())
                {

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        public void deletion(String commandText)
        {
            String connString = "Data Source=127.0.0.1;" + "Initial Catalog=movie_ticket_reservation_system;" + "User id=root;" + "Password='';";
            //String commandText = "DELETE FROM " + database_name + " WHERE auditorium_id = " + input_data;
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = new MySqlCommand(commandText, conn);
            try
            {
                MySqlDataReader reader;
                conn.Open();
                reader = command.ExecuteReader();
                MessageBox.Show("Data Deleted");
                while (reader.Read())
                {

                }
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Fill_Combo(String data_name, String database_name, ComboBox combo_box)
        {
            dbConnection dbc = new dbConnection();
            String connString = "Data Source=127.0.0.1;" + "Initial Catalog=movie_ticket_reservation_system;" + "User id=root;" + "Password='';";
            String commandText = "SELECT * FROM " + database_name;
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = new MySqlCommand(commandText, conn);
            try
            {
                MySqlDataReader reader;
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String data = reader.GetString(data_name);
                    combo_box.Items.Add(data);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Fill_Seat(String data_name, String commandText, ComboBox combo_box)
        {
            dbConnection dbc = new dbConnection();
            String connString = "Data Source=127.0.0.1;" + "Initial Catalog=movie_ticket_reservation_system;" + "User id=root;" + "Password='';";
           
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = new MySqlCommand(commandText, conn);
            try
            {
                MySqlDataReader reader;
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String data = reader.GetString(data_name);
                    combo_box.Items.Add(data);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }





        public dbConnection()
        {
           
          
        }
    }
}
