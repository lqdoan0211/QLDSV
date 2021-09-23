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
    public partial class RP_Diemhoclai_mon : Form
    {

        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=DESKTOP-SSM0BH4;Initial Catalog=QL_DiemSV;Integrated Security=True";
        public RP_Diemhoclai_mon()
        {
            InitializeComponent();
        }

        private void RP_Diemhoclai_mon_Load(object sender, EventArgs e)
        {
            

            connection = new SqlConnection(str);
            connection.Open();
            loadcb_tim_mon();

            this.reportViewer1.RefreshReport();

           
        }

        private void cb_mon_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QL_DiemSVDataSet5.Diemhoclai_mon' table. You can move, or remove it, as needed.
            this.Diemhoclai_monTableAdapter.Fill(this.QL_DiemSVDataSet5.Diemhoclai_mon, cb_mon.Text);
            // TODO: This line of code loads data into the 'QL_DiemSVDataSet5.ds_tenmon' table. You can move, or remove it, as needed.
            this.ds_tenmonTableAdapter.Fill(this.QL_DiemSVDataSet5.ds_tenmon, cb_mon.Text);
            this.reportViewer1.RefreshReport();
        }
        void loadcb_tim_mon()
        {
            var cmd = new SqlCommand("Select * From qlmon", connection);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            cb_mon.DisplayMember = "mamon";
            cb_mon.DataSource = dt;

        }
    }
}
