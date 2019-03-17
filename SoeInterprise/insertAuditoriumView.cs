using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace UTTicketReservationbyKaungMinKhant
{
    public partial class insertAuditoriumView : Form
    {
        public insertAuditoriumView()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbConnection dbconn = new dbConnection();
           
            String data_one = this.textBox1.Text;
            String data_two = this.textBox2.Text;
            String commandText = "INSERT INTO auditorium VALUES('', '" + data_one + "', '" + data_two + "')";
            dbconn.insert(commandText);
           
        }
    }
}
