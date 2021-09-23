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
    public partial class Dangky : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=DESKTOP-SSM0BH4;Initial Catalog=QL_DiemSV;Integrated Security=True";
        public Dangky()
        {
            InitializeComponent();
        }
        void load()
        {
            var cmd = new SqlCommand("Select * From Dangnhap", connection);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            
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
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Hide();
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmk_dk.Text == txtmk2_dk.Text)
                {
                    command = connection.CreateCommand();
                    command.CommandText = "Insert into Dangnhap values(N'" + txttk_dk.Text + "',N'" + txtmk_dk.Text + "',N'" + cb_quyen.Text + "', '" + lbl_role.Text + "')";
                    command.ExecuteNonQuery();
                    load();
                    MessageBox.Show("Đăng ký thành công");
                }
                else
                    MessageBox.Show("Đăng ký không thành công! Vui lòng nhập lại");
            }
            catch
            {
                MessageBox.Show("Tài khoản đã tồn tại");
            }
            
        }

        private void Dangky_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
        }

        private void cb_quyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_quyen.Text == "Giảng Viên")
            {
                lbl_role.Text = "2";
            }
            else
            {
                lbl_role.Text = "3";
            }
        }
    }
}
