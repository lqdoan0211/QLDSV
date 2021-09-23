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
    public partial class Diemthilai : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=DESKTOP-SSM0BH4;Initial Catalog=QL_DiemSV;Integrated Security=True";
        public Diemthilai()
        {
            InitializeComponent();
        }

        private void Diemthilai_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loadcb_lop();
            loadcb_mon();
            loaddiem();
            loadcbmssv_diem();
            loadcbmssv_diem();
        }
        void loadcb_lop()
        {
            var cmd = new SqlCommand("Select * From qllop", connection);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            cb_lop.DisplayMember = "malop";
            cb_lop.DataSource = dt;
        }
        void loadcb_mon()
        {
            var cmd = new SqlCommand("Select * From qlmon", connection);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            cb_mon.DisplayMember = "Mamon";
            cb_mon.DataSource = dt;
        }
        void loaddiem()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "Select * from Diemhoclai";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvhoclai.DataSource = table;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            else
            {
                connection.Close();
                connection.Open();
            }
            if (txt_hoten.Text == "" || txt_sltl.Text == "" || txt_diemkt.Text == "" || txt_diemthi.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!!!");
            }
            else if (txt_diem10.Text == "" || txt_he4.Text == "" || txt_datkh.Text == "")
            {
                MessageBox.Show("Bạn Chưa tính điểm");
            }
            else
            {
                string sql2 = "SELECT * FROM Diemhoclai where mamon = '" + cb_mon.Text + "' and mssv = '" + cbmssv_diem.Text + "' and solanthilai = '" + txt_sltl.Text + "'";
                SqlCommand cmd1 = new SqlCommand(sql2, connection);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    MessageBox.Show("Điểm của môn này đã được nhập");
                    connection.Close();
                }
                else
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    else
                    {
                        connection.Close();
                        connection.Open();
                    }
                    command = connection.CreateCommand();
                    command.CommandText = "Insert into Diemhoclai values('" + cb_lop.Text + "', N'" + cb_mon.Text + "', N'" + cbmssv_diem.Text + "', N'" + txt_hoten.Text + "',N'" + txt_sltl.Text + "',N'" + txt_diemkt.Text + "', '" + txt_diemthi.Text + "', '" + txt_diem10.Text + "', '" + txt_he4.Text + "', N'" + txt_datkh.Text + "')";
                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm điểm sinh viên thành công");
                    txt_diem10.Text = "";
                    txt_he4.Text = "";
                    txt_datkh.Text = "";
                }
            }
            loaddiem();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (txt_hoten.Text == "" || txt_sltl.Text == "" || txt_diemkt.Text == "" || txt_diemthi.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!!!");
            }
            else if (txt_diem10.Text == "" || txt_he4.Text == "" || txt_datkh.Text == "")
            {
                MessageBox.Show("Bạn Chưa tính điểm");
            }
            else
            {
                command = connection.CreateCommand();
                command.CommandText = "delete from Diemhoclai where mamon = N'" + cb_mon.Text + "' and malop = '" + cb_lop.Text + "' and mssv = '" + cbmssv_diem.Text + "' and solanthilai = '" + txt_sltl.Text + "'";
                command.ExecuteNonQuery();
                MessageBox.Show("Xóa điểm sinh viên thành công");
            }
            loaddiem();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update Diemhoclai set malop = '" + cb_lop.Text + "', mamon = N'" + cb_mon.Text + "', mssv =  N'" + cbmssv_diem.Text + "', hoten = N'" + txt_hoten.Text + "', solanthilai =  '" + txt_sltl.Text + "', dienkt = N'" + txt_diemkt.Text + "', diemthi = '" + txt_diemthi.Text + "', diemhe10 = '" + txt_diem10.Text + "',diemhe4 =  '" + txt_he4.Text + "',dathoackhong =  '" + txt_datkh.Text + "'";
            command.ExecuteNonQuery();
            MessageBox.Show("Cập nhật điểm sinh viên thành công");
            loaddiem();
        }

        private void btn_inds_Click(object sender, EventArgs e)
        {
            Thaotac.Export2Excel(dgvhoclai);
        }

        private void btn_rs_Click(object sender, EventArgs e)
        {
  
            txt_hoten.Text = "";
            txt_sltl.Text = "";
            txt_diemkt.Text = "";
            txt_diemthi.Text = "";
            txt_diem10.Text = "";
            txt_he4.Text = "";
            txt_datkh.Text = "";
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void dgvhoclai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvhoclai.CurrentRow.Index;
            cb_lop.Text = dgvhoclai.Rows[i].Cells[0].Value.ToString();
            cb_mon.Text = dgvhoclai.Rows[i].Cells[1].Value.ToString();
            cbmssv_diem.Text = dgvhoclai.Rows[i].Cells[2].Value.ToString();
            txt_hoten.Text = dgvhoclai.Rows[i].Cells[3].Value.ToString();
            txt_sltl.Text = dgvhoclai.Rows[i].Cells[4].Value.ToString();
            txt_diemkt.Text = dgvhoclai.Rows[i].Cells[5].Value.ToString();
            txt_diemthi.Text = dgvhoclai.Rows[i].Cells[6].Value.ToString();
        }

       
        private void btn_tinhdiem_Click(object sender, EventArgs e)
        {
            if (cbmssv_diem.Text == "" || txt_hoten.Text == "" || txt_diemkt.Text == "" || txt_diemthi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin ");
                return;
            }
            double kt = Convert.ToDouble(txt_diemkt.Text);
            double thi = Convert.ToDouble(txt_diemthi.Text);
            if (0 > kt || kt > 10 || 0 > thi || thi > 10)
            {
                MessageBox.Show("Vui lòng nhập điểm từ 0 đến 10 ");
                return;
            }
            double tinh = (kt * 0.3) + (thi * 0.7);
            var lamtron = Math.Round(tinh, 1);
            txt_diem10.Text = lamtron.ToString();
            if(lamtron >= 8.5)
            {
                txt_he4.Text = "A";
            }
                else if(lamtron >= 8.0)
                {
                    txt_he4.Text = "B+";
                }
                    else if (lamtron >= 7.0)
                    {
                        txt_he4.Text = "B";
                    }
                        else if (lamtron >= 6.5)
                        {
                            txt_he4.Text = "C+";
                        }
                            else if (lamtron >= 5.5)
                            {
                                txt_he4.Text = "C";
                            }
                                else if (lamtron >= 5.0)
                                {
                                    txt_he4.Text = "D+";
                                }
                                    else if (lamtron >= 4.0)
                                    {
                                        txt_he4.Text = "D";
                                    }
                                        else
                                        {
                                            txt_he4.Text = "F";
                                        }
            var xet = "F";
            if (txt_he4.Text == xet)
            {
                txt_datkh.Text = "Không Đạt";
            }
            else
            {
                txt_datkh.Text = "Đạt";
            }
        }

        void loadcbmssv_diem()
        {

            var cmd = new SqlCommand("Select * From sinhvien where malop = '" + cb_lop.Text + "'", connection);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            cbmssv_diem.DisplayMember = "mssv";
            cbmssv_diem.DataSource = dt;
            txt_hoten.DataBindings.Clear();
            txt_hoten.DataBindings.Add("Text", cbmssv_diem.DataSource, "hoten");

        }

        private void cb_lop_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadcbmssv_diem();
        }

        private void txt_sltl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txt_diemkt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txt_diemthi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
    }
}
