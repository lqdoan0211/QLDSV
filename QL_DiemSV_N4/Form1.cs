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
using System.Text.RegularExpressions;


namespace QL_DiemSV_N4
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=DESKTOP-SSM0BH4;Initial Catalog=QL_DiemSV;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
            
        }

        private string username;
        public Form1(string user)
        
        {
            InitializeComponent();
            this.username = user;
        }
        //======================================= Phân Quyền =======================//
       void action()
        {
            if (DangNhap.role == 1)
            {
                bunifuFlatButton1.Enabled = true;
                bunifuFlatButton2.Enabled = true;
                bunifuFlatButton3.Enabled = true;
                bunifuFlatButton4.Enabled = true;
            }
            else if (DangNhap.role == 2)
            {
                bunifuFlatButton1.Enabled = false;
                bunifuFlatButton2.Enabled = false;
                bunifuFlatButton3.Enabled = false;
                bunifuFlatButton4.Enabled = false;
                bunifuButton8.Enabled = false;
            }
            else
            {
                bunifuFlatButton1.Enabled = false;
                bunifuFlatButton2.Enabled = false;
                bunifuFlatButton3.Enabled = false;
                bunifuFlatButton4.Enabled = false;
                bunifuFlatButton5.Enabled = false;
                mo_dslop.Enabled = false;
                bunifuButton6.Enabled = false;
                bunifuButton7.Enabled = false;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            connection = new SqlConnection(str);
            connection.Open();
            action();
            loadsinhvien();
            loadgiaovien();
            loadlop();
            loadmon();
            loadtimkiem();
            loadtimkiem_thilai();

            loadcb_tim_mon();
            loadcbmgv_mon();
            loadcblop_sv();

            taikhoandn.Text = username;
        }
        //=================================== CODE XỬ LÝ BUTTON BÊN TRÁI ===================================//
        void Menucam(Control control)
        {
            maucam.Top = control.Top;
            maucam.Height = control.Height;
        }
        private void btnsv_Click(object sender, EventArgs e)
        {
            Menucam((Control)sender);
            bunifuPages1.SetPage("Trangchu");
        }
        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            Menucam((Control)sender);
            bunifuPages1.SetPage("Giaovien");
            magvtutang();
        }

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            Menucam((Control)sender);
            bunifuPages1.SetPage("Monhoc");
            mamontutang();
        }

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {
            Menucam((Control)sender);
            bunifuPages1.SetPage("Lop");
            maloptutang();
        }

        private void bunifuFlatButton4_Click_1(object sender, EventArgs e)
        {
            Menucam((Control)sender);
            bunifuPages1.SetPage("Sinhvien");
            sinhvientutang();
        }

        private void bunifuFlatButton5_Click_1(object sender, EventArgs e)
        {
            Menucam((Control)sender);
            bunifuPages1.SetPage("DHP");
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Menucam((Control)sender);
            bunifuPages1.SetPage("About");
            loadtimkiem();
            loadcb_tim_mon();
            loadtimkiem_thilai();
        }


        //========================================== BÊN TRÁI ====================================================//

        //========================================= CODE OPEN FORM ===============================================//
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Hide();
        }

      

        //=========================================================================================================//

        //=============================CODE XƯ LÝ CHỨC NĂNG FORM SINH VIÊN=======================//
        void loadsinhvien()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "Select * from sinhvien";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_sv.DataSource = table;
        }

        private void btnthem_sv_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_mssv_sv.Text == "" || txt_hoten_sv.Text == "" || txt_dt_sv.Text == "" || txt_qquan_sv.Text == "")
                {
                    MessageBox.Show("Dữ liệu nhập vào không được để trống");
                }
                else
                {
                    string mk = "123456";
                    string q = "Sinh viên";
                    int r = 2;
                    //thêm sinh viên
                    command = connection.CreateCommand();
                    command.CommandText = "Insert into sinhvien values('" + txt_mssv_sv.Text + "', N'" + txt_hoten_sv.Text + "', N'" + cb_gt_sv.Text + "', N'" + txt_dt_sv.Text + "', '" + cb_nsinh_sv.Value + "',N'" + txt_qquan_sv.Text + "', '" + cb_lop_sv.Text + "')";
                    command.ExecuteNonQuery();
                    //thêm tài khoản
                    command = connection.CreateCommand();
                    command.CommandText = "Insert into Dangnhap values(N'" + txt_mssv_sv.Text + "', '"+mk+"',N'" + q + "', '" + r + "')";
                    command.ExecuteNonQuery();

                    MessageBox.Show("Thêm sinh viên thành công");
                    txt_hoten_sv.Text = "";
                    txt_dt_sv.Text = "";
                    txt_qquan_sv.Text = "";
                }
                loadsinhvien();
                sinhvientutang();
                
            }
            catch
            {
                MessageBox.Show("Mã sinh viên đã có, vui lòng nhập lại");
            }
        }

        private void btnsua_sv_Click(object sender, EventArgs e)
        {
            
            command = connection.CreateCommand();
            command.CommandText = "update sinhvien set Mssv = N'" + txt_mssv_sv.Text + "', hoten = N'" + txt_hoten_sv.Text + "',gioitinh = N'" + cb_gt_sv.Text + "',dantoc = N'" + txt_dt_sv.Text + "',nsinh = N'" + cb_nsinh_sv.Value + "',diachi = N'" + txt_qquan_sv.Text + "',malop = N'" + cb_lop_sv.Text + "'  where Mssv = N'" + txt_mssv_sv.Text + "'";
            command.ExecuteNonQuery();
            MessageBox.Show("Cập nhật thông tin sinh viên thành công!!");
            txt_hoten_sv.Text = "";
            txt_dt_sv.Text = "";
            txt_qquan_sv.Text = "";
            loadsinhvien();
            sinhvientutang();

        }

        private void btnxoa_sv_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from dangnhap where taikhoan = N'" + txt_mssv_sv.Text + "'";
            command.ExecuteNonQuery();

            command = connection.CreateCommand();
            command.CommandText = "delete from QL_Diem where Mssv = N'" + txt_mssv_sv.Text + "'";
            command.ExecuteNonQuery();

            command = connection.CreateCommand();
            command.CommandText = "delete from sinhvien where Mssv = N'" + txt_mssv_sv.Text + "'";
            command.ExecuteNonQuery();

                MessageBox.Show("Xóa sinh viên thành công!!");
            loadsinhvien();
        }

        private void btnrs_sv_Click(object sender, EventArgs e)
        {
            txt_mssv_sv.ReadOnly = false;
            txt_hoten_sv.Text = "";
            txt_qquan_sv.Text = "";
            txt_dt_sv.Text = "";
            sinhvientutang();
            loadsinhvien();
        }

        private void dgv_sv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_mssv_sv.ReadOnly = true;
            int i;
            i = dgv_sv.CurrentRow.Index;
            txt_mssv_sv.Text = dgv_sv.Rows[i].Cells[0].Value.ToString();
            txt_hoten_sv.Text = dgv_sv.Rows[i].Cells[1].Value.ToString();
            cb_gt_sv.Text = dgv_sv.Rows[i].Cells[2].Value.ToString();
            txt_dt_sv.Text = dgv_sv.Rows[i].Cells[3].Value.ToString();
            txt_qquan_sv.Text = dgv_sv.Rows[i].Cells[5].Value.ToString();
            cb_lop_sv.Text = dgv_sv.Rows[i].Cells[6].Value.ToString();
        }
        void loadcblop_sv()
        {
             var cmd = new SqlCommand("Select * From qllop", connection);
              var dr = cmd.ExecuteReader();
              var dt = new DataTable();
              dt.Load(dr);
              cb_lop_sv.DisplayMember = "malop";
              cb_lop_sv.DataSource = dt;
        }

        private void btn_tim_sv_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select * from sinhvien where mssv = '" + txt_tim_mssv_sv.Text + "'";
            command.ExecuteNonQuery();
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_sv.DataSource = table;
        }    

        private void btninds_sv_Click(object sender, EventArgs e)
        {
            Thaotac.Export2Excel(dgv_sv);
        }

        //============================================ sINH VIÊN ==================================================//

        //===================================== CODE XƯ LÝ CHỨC NĂNG FORM GIẢNG VIÊN ================================//
        void loadgiaovien()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "Select * from giangvien";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_gv.DataSource = table;
        }

        private void magvtutang()
        {
            int count = 0;
            count = dgv_gv.Rows.Count;
            string chuoi = "";
            int chuoi2 = 0;
            chuoi = Convert.ToString(dgv_gv.Rows[count - 1].Cells[0].Value);
            chuoi2 = Convert.ToInt32(chuoi.Remove(0, 2));
            if(chuoi2 < 10)
            {
                txt_mgv_gv.Text = "GV0" + (chuoi2 + 1).ToString();
            }
            else
            {
                txt_mgv_gv.Text = "GV" + (chuoi2 + 1).ToString();
            }
           

        }

        private void btn_them_gv_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_mgv_gv.Text == "" || txt_hoten_gv.Text == "" || txt_email_gv.Text == "" || txt_sdt_gv.Text == "")
                {
                    MessageBox.Show("Dữ liệu nhập vào không được để trống");
                }
                else
                {
                    string mk = "123456";
                    string q = "Giảng viên";
                    int r = 3;
                    command = connection.CreateCommand();
                    command.CommandText = "Insert into giangvien values('" + txt_mgv_gv.Text + "', N'" + txt_hoten_gv.Text + "', N'" + cb_gt_gv.Text + "', '" + cb_nsinh_gv.Value + "',N'" + txt_email_gv.Text + "', '" + txt_sdt_gv.Text + "')";
                    command.ExecuteNonQuery();

                    command = connection.CreateCommand();
                    command.CommandText = "Insert into Dangnhap values(N'" + txt_mgv_gv.Text + "', '" + mk + "',N'" + q + "', '" + r + "')";
                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm giảng viên thành công");
                }
                loadgiaovien();
                loadcbmgv_mon();
                magvtutang();
            }
            catch
            {
                MessageBox.Show("Mã giảng viên đã có, vui lòng nhập lại");
            }
        }

        private void btn_sua_gv_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update giangvien set MaGV = N'" + txt_mgv_gv.Text + "', hotengv = N'" + txt_hoten_gv.Text + "',giotinh = N'" + cb_gt_gv.Text + "',nsinh = N'" + cb_nsinh_gv.Value + "',email = N'" + txt_email_gv.Text + "',sdt = N'" + txt_sdt_gv.Text + "'  where MaGV = N'" + txt_mgv_gv.Text + "'";
            command.ExecuteNonQuery();
            MessageBox.Show("Cập nhật thông tin giảng viên thành công!!");
            loadgiaovien();
            loadcbmgv_mon();
            magvtutang();
        }

        private void btn_xoa_gv_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "delete from giangvien where MaGV = N'" + txt_mgv_gv.Text + "'";
                command.ExecuteNonQuery();

                command = connection.CreateCommand();
                command.CommandText = "delete from dangnhap where taikhoan = N'" + txt_mgv_gv.Text + "'";
                command.ExecuteNonQuery();

                MessageBox.Show("Xóa Giảng viên thành công!!");
            }
            catch
            {
                MessageBox.Show("Bạn chưa xóa môn giảng viên này đang dạy!!");
            }

            loadgiaovien();
            loadcbmgv_mon();
            magvtutang();
        }
        private void btn_rs_gv_Click(object sender, EventArgs e)
        {
            txt_mgv_gv.ReadOnly = false;
            txt_hoten_gv.Text = "";
            txt_email_gv.Text = "";
            txt_sdt_gv.Text = "";
            magvtutang();
            loadgiaovien();
        }
        //=================== RÀNG BUỘC NHẬP EMAIL =======================//
        private void txt_email_gv_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txt_email_gv.Text, pattern))
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(this.txt_email_gv, "Vui lòng nhập đúng email!");
                return;
            }
        }
        //================================================================//
        private void btn_tim_gv_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select * from giangvien where MaGV = '" + txt_tim_mgv_gv.Text + "' or hotengv  = N'"+txt_tim_mgv_gv.Text+"'";
            command.ExecuteNonQuery();
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_gv.DataSource = table;
        }

        private void dgv_gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_mgv_gv.ReadOnly = true;
            int i;
            i = dgv_gv.CurrentRow.Index;
            txt_mgv_gv.Text = dgv_gv.Rows[i].Cells[0].Value.ToString().Trim();
            txt_hoten_gv.Text = dgv_gv.Rows[i].Cells[1].Value.ToString().Trim();
            cb_gt_gv.Text = dgv_gv.Rows[i].Cells[2].Value.ToString().Trim();
            txt_email_gv.Text = dgv_gv.Rows[i].Cells[4].Value.ToString().Trim();
            txt_sdt_gv.Text = dgv_gv.Rows[i].Cells[5].Value.ToString().Trim();
        }
        private void btn_inds_gv_Click(object sender, EventArgs e)
        {
            Thaotac.Export2Excel(dgv_gv);
        }

       
        //============================================= GIÁO VIÊN ==================================================//

        //===================================== CODE XƯ LÝ CHỨC NĂNG FORM LỚP HỌC ================================//
        void loadlop()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "Select * from qllop";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_lop.DataSource = table;
        }
        //========================= MÃ LỚP TỰ TĂNG ===========================//
        private void maloptutang()
        {
            int count = 0;
            count = dgv_lop.Rows.Count;
            string chuoi = "";
            int chuoi2 = 0;
            chuoi = Convert.ToString(dgv_lop.Rows[count - 1].Cells[0].Value);
            chuoi2 = Convert.ToInt32(chuoi.Remove(2, 4));
            txt_mlop_lop.Text = (chuoi2 + 1).ToString() + "DTH"; 
        }
        //=====================================================================//

        private void btn_them_lop_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_ten_lop.Text == "" || txt_mlop_lop.Text == "")
                {
                    MessageBox.Show("Dữ liệu nhập vào không được để trống!!!!!!");
                }
                else
                {
                    command = connection.CreateCommand();
                    command.CommandText = "Insert into qllop values('" + txt_mlop_lop.Text + "', N'" + txt_ten_lop.Text + "')";
                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm lớp thành công!!");
                    txt_ten_lop.Text = "";
                }
                
                loadlop();
                maloptutang();
            }
            catch
            {
               
                 MessageBox.Show("Dữ liệu đã có vui, lòng nhập lại!!!");
                
            }
        }

        private void btn_sua_lop_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update qllop set malop = N'" + txt_mlop_lop.Text + "', tenlop = N'" + txt_ten_lop.Text + "'  where malop = N'" + txt_mlop_lop.Text + "'";
            command.ExecuteNonQuery();
            MessageBox.Show("Cập nhật thông tin lớp thành công!!");
            loadlop();
        }

        private void btn_xoa_lop_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from sinhvien where malop = N'" + txt_mlop_lop.Text + "'";
            command.ExecuteNonQuery();

            command = connection.CreateCommand();
            command.CommandText = "delete from QL_Diem where malop = N'" + txt_mlop_lop.Text + "'";
            command.ExecuteNonQuery();

            command = connection.CreateCommand();
            command.CommandText = "delete from Diemhoclai where malop = N'" + txt_mlop_lop.Text + "'";
            command.ExecuteNonQuery();

            command = connection.CreateCommand();
            command.CommandText = "delete from qllop where malop = N'" + txt_mlop_lop.Text + "'";
            command.ExecuteNonQuery();
            MessageBox.Show("Xóa lớp thành công");

            loadlop();
            maloptutang();
        }

        private void btn_rs_lop_Click(object sender, EventArgs e)
        {
            txt_mlop_lop.ReadOnly = false;
            txt_mlop_lop.Text = "";
            txt_ten_lop.Text = "";
            maloptutang();
            loadlop();
        }
        private void dgv_lop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_mlop_lop.ReadOnly = true;
            int i;
            i = dgv_lop.CurrentRow.Index;
            txt_mlop_lop.Text = dgv_lop.Rows[i].Cells[0].Value.ToString();
            txt_ten_lop.Text = dgv_lop.Rows[i].Cells[1].Value.ToString();
        }

        private void btn_inds_lop_Click(object sender, EventArgs e)
        {
            Thaotac.Export2Excel(dgv_lop);
        }

        //================================================= LỚP HỌC ================================================//

        //===================================== CODE XƯ LÝ CHỨC NĂNG FORM MÔN HỌC ================================//
        void loadmon()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "Select * from qlmon";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_mon.DataSource = table;
        }
        void loadcbmgv_mon()
        {
            var cmd = new SqlCommand("Select * From giangvien", connection);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            cb_mgv_mon.DisplayMember = "MaGV";
            cb_mgv_mon.DataSource = dt;
           
        }
        //=========================== MÃ MÔN TỰ TĂNG ==========================//
        private void mamontutang()
        {
            int count = 0;
            count = dgv_mon.Rows.Count;
            string chuoi = "";
            int chuoi2 = 0;
            chuoi = Convert.ToString(dgv_mon.Rows[count - 1].Cells[0].Value);
            chuoi2 = Convert.ToInt32(chuoi.Remove(0, 2));
            if (chuoi2 < 10)
            {
                txt_ma_mon.Text = "M0" + (chuoi2 + 1).ToString();
            }
            else
            {
                txt_ma_mon.Text = "M" + (chuoi2 + 1).ToString();
            }
        }
        //==================================================================//
        private void btn_them_mon_Click(object sender, EventArgs e)
        {
            try
            {
                if(txt_ma_mon.Text == "" || txt_ten_mon.Text =="" || txt_stc_mon.Text == "" || txt_lt_mon.Text == "" || txt_th_mon.Text == "" || txt_bt_mon.Text == "" || txt_hocky_mon.Text == "")
                {
                    MessageBox.Show("Dữ liệu nhập vào không được để trống");
                }
                else
                {
                    command = connection.CreateCommand();
                    command.CommandText = "Insert into qlmon values('" + txt_ma_mon.Text + "', N'" + txt_ten_mon.Text + "', '" + txt_stc_mon.Text + "', '" + txt_lt_mon.Text + "',N'" + txt_th_mon.Text + "', '" + txt_bt_mon.Text + "', N'" + cb_mgv_mon.Text + "', '" + txt_hocky_mon.Text + "')";
                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm môn học mới thành công");
                }
                
                loadmon();
                mamontutang();
                // loadcb_tim_mon();
            }
            catch
            {
                MessageBox.Show("Mã môn học dã có, vui lòng nhập lại");
            }
        }

        private void btn_sua_mon_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update qlmon set Mamon = '" + txt_ma_mon.Text + "', tenmon =  N'" + txt_ten_mon.Text + "', sotc = '" + txt_stc_mon.Text + "', sotietth = '" + txt_lt_mon.Text + "', sotietlt = '" + txt_th_mon.Text + "', sotietbt = '" + txt_bt_mon.Text + "', magv = N'" + cb_mgv_mon.Text + "', hocky = '" + txt_hocky_mon.Text + "' where mamon = '"+txt_ma_mon.Text+"'";
            command.ExecuteNonQuery();
            MessageBox.Show("Cập nhật thông tin môn học thành công!!");
            loadmon();
            mamontutang();
           // loadcb_tim_mon();
        }

        private void txt_xoa_mon_Click(object sender, EventArgs e)
        {
            

            command = connection.CreateCommand();
            command.CommandText = "delete from QL_Diem where mamon = N'" + txt_ma_mon.Text + "'";
            command.ExecuteNonQuery();

            command = connection.CreateCommand();
            command.CommandText = "delete from Diemhoclai where mamon = N'" + txt_ma_mon.Text + "'";
            command.ExecuteNonQuery();

            command = connection.CreateCommand();
            command.CommandText = "delete from qlmon where mamon = N'" + txt_ma_mon.Text + "'";
            command.ExecuteNonQuery();
            MessageBox.Show("Xóa môn học thành công!!");
            loadmon();
            mamontutang();
           // loadcb_tim_mon();
        }

        private void btn_rs_mon_Click(object sender, EventArgs e)
        {
            txt_ma_mon.ReadOnly = false;
            txt_ten_mon.Text = "";
            txt_stc_mon.Text = "";
            txt_lt_mon.Text = "";
            txt_th_mon.Text = "";
            txt_bt_mon.Text = "";
            txt_hocky_mon.Text = "";
            mamontutang();
            loadmon();
        }

        private void btn_tim_mon_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select * from qlmon where Mamon = '" + txt_tim_mon.Text + "' or tenmon = N'" + txt_tim_mon.Text + "' or magv = '"+txt_tim_mon.Text+"'";
            command.ExecuteNonQuery();
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_mon.DataSource = table;
        }
        private void dgv_mon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ma_mon.ReadOnly = true;
            int i;
            i = dgv_mon.CurrentRow.Index;
            txt_ma_mon.Text = dgv_mon.Rows[i].Cells[0].Value.ToString();
            txt_ten_mon.Text = dgv_mon.Rows[i].Cells[1].Value.ToString();
            txt_stc_mon.Text = dgv_mon.Rows[i].Cells[2].Value.ToString();
            txt_lt_mon.Text = dgv_mon.Rows[i].Cells[3].Value.ToString();
            txt_th_mon.Text = dgv_mon.Rows[i].Cells[4].Value.ToString();
            txt_bt_mon.Text = dgv_mon.Rows[i].Cells[5].Value.ToString();
            cb_mgv_mon.Text = dgv_mon.Rows[i].Cells[6].Value.ToString();
            txt_hocky_mon.Text = dgv_mon.Rows[i].Cells[7].Value.ToString();
        }

        private void txt_inds_mon_Click(object sender, EventArgs e)
        {
            Thaotac.Export2Excel(dgv_mon);
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Diemlan1 d1 = new Diemlan1();
            d1.ShowDialog();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            Diemthilai d1 = new Diemthilai();
            d1.ShowDialog();
        }

        //========================================= TRA CỨU ĐIỂM ===========================================//

        void loadcb_tim_mon()
        {
            var cmd = new SqlCommand("Select * From qlmon", connection);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            cb_tim_mon.DisplayMember = "Mamon";
            cb_tim_mon.DataSource = dt;

        }
        void loadtimkiem()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "Select * from QL_Diem";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_timkiem.DataSource = table;
        }
        void loadtimkiem_thilai()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "Select * from Diemhoclai";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_tim_hoclai.DataSource = table;
        }
        private void btn_timkiem_Click(object sender, EventArgs e)
        {
           if(cb_tim_diem.Text == "ĐIỂM THI LẦN 1")
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                command = connection.CreateCommand();
                command.CommandText = "select * from QL_Diem where mssv = '" + txt_tim_mssv.Text + "' and mamon = '" + cb_tim_mon.Text + "'";
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dgv_timkiem.DataSource = table;
            }
            else
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                command = connection.CreateCommand();
                command.CommandText = "select * from Diemhoclai where mssv = '" + txt_tim_mssv.Text + "' and mamon = '" + cb_tim_mon.Text + "'";
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dgv_tim_hoclai.DataSource = table;
            }
        }
        //========================================================================================================================================//

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát khỏi chương trình!!", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txt_tim_mssv_sv.Text = "";
        }

        private void mo_dslop_Click(object sender, EventArgs e)
        {
            RP_Sinhvien_lop openform = new RP_Sinhvien_lop();
            openform.Show();
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            RP_Diemsv_mon openform = new RP_Diemsv_mon();
            openform.Show();
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            RP_Diemhoclai_mon openform = new RP_Diemhoclai_mon();
            openform.Show();
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {

            RP_Bangdiem openform = new RP_Bangdiem(taikhoandn.Text);
            openform.ShowDialog();
        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            RSpassword openform = new RSpassword(taikhoandn.Text);
            openform.ShowDialog();
        }

        private void txt_lt_mon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txt_bt_mon_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_th_mon_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_sdt_gv_KeyPress(object sender, KeyPressEventArgs e)
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
        
 
        private void cb_lop_sv_SelectedIndexChanged(object sender, EventArgs e)
        {
            sinhvientutang();
        }
        private void sinhvientutang()
        {
            //=========== LOAD SINH VIÊN THEO LỚP===============//
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "Select * from sinhvien where malop = '" + cb_lop_sv.Text + "'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_sv.DataSource = table;
            //======================================================//

            //=========== MSSV TỰ TĂNG ============//
            int count = 0;
            count = dgv_sv.Rows.Count;
            string ma = cb_lop_sv.Text.Substring(0, 2);
            string ma1 = cb_lop_sv.Text.Substring(2, 1);
            string ma2 = (int.Parse(ma) + 6).ToString() + ma1 + "4802010";
            string chuoi = "";
            int ma3 = 0;
            if (count <= 0)
            {
                string mas = "01";
                string ma4 = ma2 + mas;
                txt_mssv_sv.Text = ma4;
            }
            else
            {
                chuoi = Convert.ToString(dgv_sv.Rows[count - 1].Cells[0].Value);
                ma3 = Convert.ToInt32(chuoi.Remove(0, 10));
                string ma4 = ma2 + (ma3 + 1);
                txt_mssv_sv.Text = ma4;
            }
        }
        //========================= ĐĂNG XUẤT ================//
        private void bunifuButton10_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Hide();
        }

    }

}
