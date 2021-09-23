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
    public partial class RSpassword : Form
    {
        SqlConnection conn;
        SqlCommand command;
        string str = "Data Source=DESKTOP-SSM0BH4;Initial Catalog=QL_DiemSV;Integrated Security=True";
        public RSpassword()
        {
            InitializeComponent();          
        }
        private string username;
        public RSpassword(string user)
        {
            InitializeComponent();
            this.username = user;
        }
        private void RSpassword_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();

            lbl_tk.Text = username;

            string sql = @"select * from dangnhap where taikhoan = '" + lbl_tk.Text.Trim() + "' ";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);//connection là cái SqlConnection của bạn ấy nhé
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lbl_quyen.Text = dt.Rows[0]["quyen"].ToString().Trim();
                lbl_role.Text = dt.Rows[0]["role"].ToString().Trim();
            }
            
        }

        private void btn_doimk_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            else
            {
                conn.Close();
                conn.Open();
            }
            string sql = "SELECT * FROM dangnhap WHERE taikhoan='" + lbl_tk.Text + "'and matKhau='" + txt_mk.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            if (dta.Read() == false)
            {
                MessageBox.Show("Mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_mk.Text = "";
                txt_mkm.Text = "";
                txt_nlmk.Text = "";
            }
            else
            {
                if (txt_mkm.Text != txt_nlmk.Text)
                {
                    MessageBox.Show("Mật khẩu mới phải trùng nhau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                    txt_nlmk.Text = "";
                }
                else
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    else
                    {
                        conn.Close();
                        conn.Open();
                    }
                    string sql2 = "update dangnhap set taikhoan = N'" + lbl_tk.Text + "', matkhau = N'" + txt_mkm.Text + "', quyen = '" + lbl_quyen.Text + "', role = '" + lbl_role.Text + "'  where taikhoan = N'" + lbl_tk.Text + "'";
                    SqlCommand cmd2 = new SqlCommand(sql2, conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Đổi mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
    }
}
