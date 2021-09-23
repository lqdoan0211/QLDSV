using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_DiemSV_N4
{
    public partial class RP_Bangdiem : Form
    {
        public RP_Bangdiem()
        {
            InitializeComponent();
        }
        private string username;
        public RP_Bangdiem(string user)
        {
            InitializeComponent();
            this.username = user;

        }

        private void RP_Bangdiem_Load(object sender, EventArgs e)
        {
            lbl_mssv.Text = username;
            // TODO: This line of code loads data into the 'QL_DiemSVDataSet5.Diem_sinhvien' table. You can move, or remove it, as needed.
            this.Diem_sinhvienTableAdapter.Fill(this.QL_DiemSVDataSet5.Diem_sinhvien, lbl_mssv.Text);
            // TODO: This line of code loads data into the 'QL_DiemSVDataSet5.Diemhoclai_sinhvien' table. You can move, or remove it, as needed.
            this.Diemhoclai_sinhvienTableAdapter.Fill(this.QL_DiemSVDataSet5.Diemhoclai_sinhvien, lbl_mssv.Text);
            // TODO: This line of code loads data into the 'QL_DiemSVDataSet5.DS_SinhVien' table. You can move, or remove it, as needed.
            this.DS_SinhVienTableAdapter.Fill(this.QL_DiemSVDataSet5.DS_SinhVien, lbl_mssv.Text);

            this.reportViewer1.RefreshReport();
        }
    }
}
