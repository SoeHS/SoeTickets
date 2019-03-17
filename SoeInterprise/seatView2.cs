using Microsoft.VisualBasic;
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
    public partial class seatView2 : Form
    {
        public seatView2()
        {
            InitializeComponent();
            Table_Load();
        }

        public void Table_Load()
        {
            dbConnection dbc = new dbConnection();
            dbc.selection("seat", dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String database_name = "seat";
            String input_data = Interaction.InputBox("Enter the id of the seat", "Delete", "", 0, 0);
            String commandText = "DELETE FROM " + database_name + " WHERE seat_id = " + input_data;
            dbConnection DBC = new dbConnection();
            DBC.deletion(commandText);
            Table_Load();
        }
    }
}
