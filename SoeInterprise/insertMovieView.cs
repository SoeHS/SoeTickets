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
    public partial class insertMovieView : Form
    {
        public insertMovieView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String data_one = this.textBox1.Text;
            String data_two = this.textBox2.Text;
            String data_three = this.textBox3.Text;
            String data_four = this.textBox4.Text;
            String data_five = this.textBox5.Text;
            String commandText = "INSERT INTO `moive` (`movie_id`, `movie_title`, `movie_director`, `movie_cast`, `movie_description`, `movie_duration_min`) VALUES (NULL, '" + data_one + "', '" + data_two + "', '" + data_three + "', '" + data_four + "', '" + data_five + "')";
            dbConnection dbc = new dbConnection();
            dbc.insert(commandText);
        }
    }
}
