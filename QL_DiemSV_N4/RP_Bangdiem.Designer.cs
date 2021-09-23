namespace QL_DiemSV_N4
{
    partial class RP_Bangdiem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Diem_sinhvienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QL_DiemSVDataSet5 = new QL_DiemSV_N4.QL_DiemSVDataSet5();
            this.Diemhoclai_sinhvienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DS_SinhVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_mssv = new System.Windows.Forms.Label();
            this.Diem_sinhvienTableAdapter = new QL_DiemSV_N4.QL_DiemSVDataSet5TableAdapters.Diem_sinhvienTableAdapter();
            this.Diemhoclai_sinhvienTableAdapter = new QL_DiemSV_N4.QL_DiemSVDataSet5TableAdapters.Diemhoclai_sinhvienTableAdapter();
            this.DS_SinhVienTableAdapter = new QL_DiemSV_N4.QL_DiemSVDataSet5TableAdapters.DS_SinhVienTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.Diem_sinhvienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QL_DiemSVDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Diemhoclai_sinhvienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_SinhVienBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Diem_sinhvienBindingSource
            // 
            this.Diem_sinhvienBindingSource.DataMember = "Diem_sinhvien";
            this.Diem_sinhvienBindingSource.DataSource = this.QL_DiemSVDataSet5;
            // 
            // QL_DiemSVDataSet5
            // 
            this.QL_DiemSVDataSet5.DataSetName = "QL_DiemSVDataSet5";
            this.QL_DiemSVDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Diemhoclai_sinhvienBindingSource
            // 
            this.Diemhoclai_sinhvienBindingSource.DataMember = "Diemhoclai_sinhvien";
            this.Diemhoclai_sinhvienBindingSource.DataSource = this.QL_DiemSVDataSet5;
            // 
            // DS_SinhVienBindingSource
            // 
            this.DS_SinhVienBindingSource.DataMember = "DS_SinhVien";
            this.DS_SinhVienBindingSource.DataSource = this.QL_DiemSVDataSet5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "MSSV:";
            // 
            // lbl_mssv
            // 
            this.lbl_mssv.AutoSize = true;
            this.lbl_mssv.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mssv.Location = new System.Drawing.Point(71, 9);
            this.lbl_mssv.Name = "lbl_mssv";
            this.lbl_mssv.Size = new System.Drawing.Size(14, 18);
            this.lbl_mssv.TabIndex = 8;
            this.lbl_mssv.Text = "*";
            // 
            // Diem_sinhvienTableAdapter
            // 
            this.Diem_sinhvienTableAdapter.ClearBeforeFill = true;
            // 
            // Diemhoclai_sinhvienTableAdapter
            // 
            this.Diemhoclai_sinhvienTableAdapter.ClearBeforeFill = true;
            // 
            // DS_SinhVienTableAdapter
            // 
            this.DS_SinhVienTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Diem";
            reportDataSource1.Value = this.Diem_sinhvienBindingSource;
            reportDataSource2.Name = "Diemhoclai";
            reportDataSource2.Value = this.Diemhoclai_sinhvienBindingSource;
            reportDataSource3.Name = "sinhvien";
            reportDataSource3.Value = this.DS_SinhVienBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QL_DiemSV_N4.rp_Bangdiem_mssv.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(888, 811);
            this.reportViewer1.TabIndex = 9;
            // 
            // RP_Bangdiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(888, 811);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.lbl_mssv);
            this.Controls.Add(this.label1);
            this.Name = "RP_Bangdiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RP_Bangdiem";
            this.Load += new System.EventHandler(this.RP_Bangdiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Diem_sinhvienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QL_DiemSVDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Diemhoclai_sinhvienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_SinhVienBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_mssv;
        private System.Windows.Forms.BindingSource Diem_sinhvienBindingSource;
        private QL_DiemSVDataSet5 QL_DiemSVDataSet5;
        private System.Windows.Forms.BindingSource Diemhoclai_sinhvienBindingSource;
        private System.Windows.Forms.BindingSource DS_SinhVienBindingSource;
        private QL_DiemSVDataSet5TableAdapters.Diem_sinhvienTableAdapter Diem_sinhvienTableAdapter;
        private QL_DiemSVDataSet5TableAdapters.Diemhoclai_sinhvienTableAdapter Diemhoclai_sinhvienTableAdapter;
        private QL_DiemSVDataSet5TableAdapters.DS_SinhVienTableAdapter DS_SinhVienTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}