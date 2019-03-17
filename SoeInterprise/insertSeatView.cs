using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTTicketReservationbyKaungMinKhant
{
    public partial class insertSeatView : Form
    {
        String data_three;
        public insertSeatView()
        {
            InitializeComponent();
            dbConnection dbc = new dbConnection();
            dbc.Fill_Combo("auditorium_name", "auditorium", comboBox1);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            dbConnection dbc = new dbConnection();
            String data_one = this.textBox1.Text;
            String data_two = this.textBox3.Text;
            String selectedindex = comboBox1.SelectedItem.ToString();
            //String commandText = "INSERT INTO `seat` (`seat_id`, `seat_row`, `seat_number`, `auditorium_id`) VALUES (NULL, '"+ data_one + "', '" + data_two + "', '" + data_three + "')";
            //dbc.insert(commandText);


            String connString = "Data Source=127.0.0.1;" + "Initial Catalog=movie_ticket_reservation_system;" + "User id=root;" + "Password='';";

            String get_id = "SELECT * FROM auditorium WHERE auditorium_name = " + "'"+ selectedindex + "'";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = new MySqlCommand(get_id, conn);
            Datagyi dg = new Datagyi();
            try
            {
                MySqlDataReader reader;
                conn.Open();
                reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    String data_three = reader["auditorium_id"].ToString();
                    
                    String commandText = "INSERT INTO `seat` (`seat_id`, `seat_row`, `seat_number`, `auditorium_id`) VALUES (NULL, '"+ data_one + "', '" + data_two + "', '" + data_three + "')";
                    dbc.insert(commandText);
                }
                Console.ReadLine();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
