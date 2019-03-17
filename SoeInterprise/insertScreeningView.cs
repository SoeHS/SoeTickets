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
    public partial class insertScreeningView : Form
    {
        public insertScreeningView()
        {
            InitializeComponent();
            dbConnection dbc = new dbConnection();
            dbc.Fill_Combo("movie_title", "moive", comboBox1);
            dbc.Fill_Combo("auditorium_name", "auditorium", comboBox2);
            Fillcombothree();
            
        }
        public void Fillcombothree()
        {
            comboBox3.Items.Add("10:00");
            comboBox3.Items.Add("12:00");
            comboBox3.Items.Add("15:00");
            comboBox3.Items.Add("19:00");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbConnection dbc = new dbConnection();
           
            String selectedindex1 = comboBox1.SelectedItem.ToString();
            String selectedindex2 = comboBox2.SelectedItem.ToString();
            String data_three = comboBox3.SelectedItem.ToString();
            
            //String commandText = "INSERT INTO `seat` (`seat_id`, `seat_row`, `seat_number`, `auditorium_id`) VALUES (NULL, '"+ data_one + "', '" + data_two + "', '" + data_three + "')";
            //dbc.insert(commandText);


            String connString = "Data Source=127.0.0.1;" + "Initial Catalog=movie_ticket_reservation_system;" + "User id=root;" + "Password='';";

            String get_id = "SELECT * FROM moive WHERE movie_title = " + "'" + selectedindex1 + "'";
            String get_id2 = "SELECT * FROM auditorium WHERE auditorium_name = " + "'" + selectedindex2 + "'";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = new MySqlCommand(get_id, conn);
            MySqlCommand command2 = new MySqlCommand(get_id2, conn);
           
            try
            {
                MySqlDataReader reader;
                conn.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    String data_one = reader["movie_id"].ToString();
                    conn.Close();
                    try
                    {
                        MySqlDataReader reader1;
                        conn.Open();
                        reader1 = command2.ExecuteReader();
                        while (reader1.Read())
                        {
                            String data_two = reader1["auditorium_id"].ToString();
                            
                            String commandText = "INSERT INTO `screening` (`screening_id`, `movie_id`, `auditorium_id`, `screening_start`) VALUES (NULL, '" + data_one + "', '" + data_two + "', '" + data_three + "')";
                            dbc.insert(commandText);
                        }
                    }
                    catch(Exception ex)
                    {
                        
                    }
                    
                    

                }
                conn.Close();
                Console.ReadLine();
                
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}
