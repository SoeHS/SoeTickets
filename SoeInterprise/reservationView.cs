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
    public partial class reservationView : Form
    {
        public reservationView()
        {
            InitializeComponent();
            dbConnection dbc = new dbConnection();
            dbc.Fill_Combo("auditorium_name", "auditorium", comboBox1);
            dbc.Fill_Combo("movie_title", "moive", comboBox3);
            dbc.Fill_Combo("screening_start", "screening", comboBox5);  
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String auditorium_name = comboBox1.SelectedItem.ToString();
            String movie_title = comboBox3.SelectedItem.ToString();
            String screening_start = comboBox5.SelectedItem.ToString();
            this.Hide();
           
            reservation2 r2 = new reservation2(auditorium_name, movie_title, screening_start);
            r2.ShowDialog();
        }
    }
}
