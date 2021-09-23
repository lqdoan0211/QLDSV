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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        public static int role;
        public static string quyen;

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-SSM0BH4;Initial Catalog=QL_DiemSV;Integrated Security=True");
            try
            {
                conn.Open();
                string tk = txttk.Text;
                string mk = txtmk.Text;
                string sql = "select role, quyen from dangnhap where taikhoan=@taikhoan and matkhau=@matkhau";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("taikhoan", tk);
                cmd.Parameters.AddWithValue("matkhau", mk);
                SqlDataReader dta = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(dta);
                dta.Dispose();
                if (dt.Rows.Count > 0)
                {
                    role = (int)dt.Rows[0][0];
                    quyen = dt.Rows[0][1].ToString().Trim();
                    Form1 openform = new Form1(txttk.Text);
                    this.Hide();
                    openform.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!!!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát khỏi trang đăng nhập!!", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Dangky DK = new Dangky();
            DK.Show();
            this.Hide();
        }

    }
}
