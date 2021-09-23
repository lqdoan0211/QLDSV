namespace QL_DiemSV_N4
{
    partial class RP_Diemsv_mon
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
            this.Diemthilan1_monBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QL_DiemSVDataSet5 = new QL_DiemSV_N4.QL_DiemSVDataSet5();
            this.ds_tenmonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cb_mon = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Diemthilan1_monTableAdapter = new QL_DiemSV_N4.QL_DiemSVDataSet5TableAdapters.Diemthilan1_monTableAdapter();
            this.ds_tenmonTableAdapter = new QL_DiemSV_N4.QL_DiemSVDataSet5TableAdapters.ds_tenmonTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Diemthilan1_monBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QL_DiemSVDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_tenmonBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Diemthilan1_monBindingSource
            // 
            this.Diemthilan1_monBindingSource.DataMember = "Diemthilan1_mon";
            this.Diemthilan1_monBindingSource.DataSource = this.QL_DiemSVDataSet5;
            // 
            // QL_DiemSVDataSet5
            // 
            this.QL_DiemSVDataSet5.DataSetName = "QL_DiemSVDataSet5";
            this.QL_DiemSVDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ds_tenmonBindingSource
            // 
            this.ds_tenmonBindingSource.DataMember = "ds_tenmon";
            this.ds_tenmonBindingSource.DataSource = this.QL_DiemSVDataSet5;
            // 
            // cb_mon
            // 
            this.cb_mon.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_mon.FormattingEnabled = true;
            this.cb_mon.Location = new System.Drawing.Point(127, 18);
            this.cb_mon.Name = "cb_mon";
            this.cb_mon.Size = new System.Drawing.Size(239, 25);
            this.cb_mon.TabIndex = 0;
            this.cb_mon.SelectedIndexChanged += new System.EventHandler(this.cb_mon_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "CHỌN MÔN";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Diemthilan1_monBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.ds_tenmonBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QL_DiemSV_N4.rp_diemlan1_mon.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 54);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(852, 695);
            this.reportViewer1.TabIndex = 2;
            // 
            // Diemthilan1_monTableAdapter
            // 
            this.Diemthilan1_monTableAdapter.ClearBeforeFill = true;
            // 
            // ds_tenmonTableAdapter
            // 
            this.ds_tenmonTableAdapter.ClearBeforeFill = true;
            // 
            // RP_Diemsv_mon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(876, 761);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_mon);
            this.Name = "RP_Diemsv_mon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RP_Diemsv_mon";
            this.Load += new System.EventHandler(this.RP_Diemsv_mon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Diemthilan1_monBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QL_DiemSVDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_tenmonBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_mon;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Diemthilan1_monBindingSource;
        private QL_DiemSVDataSet5 QL_DiemSVDataSet5;
        private System.Windows.Forms.BindingSource ds_tenmonBindingSource;
        private QL_DiemSVDataSet5TableAdapters.Diemthilan1_monTableAdapter Diemthilan1_monTableAdapter;
        private QL_DiemSVDataSet5TableAdapters.ds_tenmonTableAdapter ds_tenmonTableAdapter;
    }
}