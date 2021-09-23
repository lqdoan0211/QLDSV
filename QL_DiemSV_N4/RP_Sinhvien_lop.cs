using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QL_DiemSV_N4
{
    public partial class RP_Sinhvien_lop : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=DESKTOP-SSM0BH4;Initial Catalog=QL_DiemSV;Integrated Security=True";
        public RP_Sinhvien_lop()
        {
            InitializeComponent();
        }

        private void RP_Sinhvien_lop_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loadcb_tim_lop();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QL_DiemSVDataSet2.dssinhvien_lop' table. You can move, or remove it, as needed.
            this.dssinhvien_lopTableAdapter.Fill(this.QL_DiemSVDataSet2.dssinhvien_lop, comboBox1.Text);

            this.reportViewer1.RefreshReport();
        }
        void loadcb_tim_lop()
        {
            var cmd = new SqlCommand("Select * From qllop", connection);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            comboBox1.DisplayMember = "malop";
            comboBox1.DataSource = dt;

        }
    }
}
