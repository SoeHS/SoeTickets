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
    public partial class movieView : Form
    {
        public movieView()
        {
            InitializeComponent();
            dbConnection dbc = new dbConnection();
            dbc.selection("moive", dataGridView1);
        }
       
    }
}
