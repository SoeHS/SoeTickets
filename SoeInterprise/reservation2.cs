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
    public partial class reservation2 : Form
    {
        public reservation2(String auditorium_name, String movie_title, String screening_start)
        {
            InitializeComponent();
            this.label3.Text = auditorium_name.ToString();
            this.label4.Text = movie_title.ToString();
            this.label5.Text = screening_start.ToString();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            
            String connString = "Data Source=127.0.0.1;" + "Initial Catalog=movie_ticket_reservation_system;" + "User id=root;" + "Password='';";
            String get_id = "SELECT * FROM auditorium WHERE auditorium_name = " + "'" + this.label3.Text + "'";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand command = new MySqlCommand(get_id, conn);
            try
            {
                MySqlDataReader reader;
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String auditorium_id = reader["auditorium_id"].ToString();
                    String data_to_be_filled_in_seat = "seat_number";
                    String commandText1 = "SELECT * FROM seat WHERE auditorium_id = " + "'" + auditorium_id + "'";
                    dbConnection dbc = new dbConnection();
                    dbc.Fill_Seat(data_to_be_filled_in_seat, commandText1, comboBox1);
                    conn.Close();
                }
            }
            catch
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String auditorium_name = this.label3.Text;
            String movie_title = this.label4.Text;
            String screening_start = this.label5.Text;
            String seat_number = this.comboBox1.SelectedItem.ToString();
            String cost = this.textBox2.Text;
            String connString = "Data Source=127.0.0.1;" + "Initial Catalog=movie_ticket_reservation_system;" + "User id=root;" + "Password='';";
            String get_id = "SELECT * FROM auditorium WHERE auditorium_name = " + "'" + auditorium_name + "'";
            String get_id2 = "SELECT * FROM moive WHERE movie_title = " + "'" + movie_title + "'";
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
                    String auditorium_id = reader["auditorium_id"].ToString();
                    conn.Close();
                    try
                    {
                        MySqlDataReader reader2;
                        conn.Open();
                        reader2 = command2.ExecuteReader();
                        while (reader2.Read())
                        {
                            String movie_id = reader2["movie_id"].ToString();
                            conn.Close();
                            String get_screening_id = "SELECT * FROM screening WHERE movie_id = " + "'" + movie_id + "'" + " AND auditorium_id = " + "'" + auditorium_id + "'" + "AND screening_start = " + "'" + screening_start + "'";
                            MySqlCommand command3 = new MySqlCommand(get_screening_id, conn);
                            try
                            {
                                MySqlDataReader reader3;
                                conn.Open();
                                reader3 = command3.ExecuteReader();
                                while (reader3.Read())
                                {
                                    String screening_id = reader3["screening_id"].ToString();
                                    conn.Close();
                                    String get_seat_id = "SELECT * FROM seat WHERE seat_number = " + "'" + seat_number + "'";
                                    MySqlCommand command4 = new MySqlCommand(get_seat_id, conn);
                                    try
                                    {
                                        MySqlDataReader reader4;
                                        conn.Open();
                                        reader4 = command4.ExecuteReader();
                                        while (reader4.Read())
                                        {
                                            String seat_id = reader4["seat_id"].ToString();
                                            conn.Close();
                                            dbConnection dbc = new dbConnection();
                                            String commandText = "INSERT INTO `finalreservation` (`res_id`, `screening_id`, `seat_id`, `cost`) VALUES (NULL, '" + screening_id + "', '" + seat_id + "', '" + cost + "')";
                                            dbc.insert(commandText);
                                        }
                                    }
                                    catch(Exception ex)
                                    {

                                    }
                                }
                            }
                            catch(Exception ex)
                            {

                            }
                        }
                    }
                    catch(Exception ex)
                    {

                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
