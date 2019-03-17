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
    public partial class adminpanelViewcs : Form
    {
        public adminpanelViewcs()
        {
            InitializeComponent();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {

           

          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            insertDataView idv = new insertDataView();
            idv.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dbConnection dbconn = new dbConnection();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            auditoriumView av = new auditoriumView();
            av.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            seatView2 sv2 = new seatView2();
            sv2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            movieView mv = new movieView();
            mv.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            screeningView sv = new screeningView();
            sv.ShowDialog();
        }
    }
}
