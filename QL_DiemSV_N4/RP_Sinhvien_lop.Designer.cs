namespace QL_DiemSV_N4
{
    partial class RP_Sinhvien_lop
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
            this.dssinhvien_lopBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QL_DiemSVDataSet2 = new QL_DiemSV_N4.QL_DiemSVDataSet2();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dssinhvien_lopTableAdapter = new QL_DiemSV_N4.QL_DiemSVDataSet2TableAdapters.dssinhvien_lopTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dssinhvien_lopBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QL_DiemSVDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // dssinhvien_lopBindingSource
            // 
            this.dssinhvien_lopBindingSource.DataMember = "dssinhvien_lop";
            this.dssinhvien_lopBindingSource.DataSource = this.QL_DiemSVDataSet2;
            // 
            // QL_DiemSVDataSet2
            // 
            this.QL_DiemSVDataSet2.DataSetName = "QL_DiemSVDataSet2";
            this.QL_DiemSVDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(126, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 25);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dssinhvien_lopBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QL_DiemSV_N4.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 53);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(791, 631);
            this.reportViewer1.TabIndex = 1;
            // 
            // dssinhvien_lopTableAdapter
            // 
            this.dssinhvien_lopTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "CHỌN LỚP";
            // 
            // RP_Sinhvien_lop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 696);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.comboBox1);
            this.Name = "RP_Sinhvien_lop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DANH SÁCH SINH VIÊN THEO LỚP";
            this.Load += new System.EventHandler(this.RP_Sinhvien_lop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dssinhvien_lopBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QL_DiemSVDataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dssinhvien_lopBindingSource;
        private QL_DiemSVDataSet2 QL_DiemSVDataSet2;
        private QL_DiemSVDataSet2TableAdapters.dssinhvien_lopTableAdapter dssinhvien_lopTableAdapter;
        private System.Windows.Forms.Label label1;
    }
}