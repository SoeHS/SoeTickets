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
    public partial class screeningView : Form
    {
        public screeningView()
        {
            InitializeComponent();
            dbConnection dbc = new dbConnection();
            dbc.selection("screening", dataGridView1);
        }
    }
}
