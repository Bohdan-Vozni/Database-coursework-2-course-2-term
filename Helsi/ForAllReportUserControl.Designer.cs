namespace Helsi
{
    partial class ForAllReportUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            report_dataGridView = new DataGridView();
            printReport = new Button();
            ((System.ComponentModel.ISupportInitialize)report_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // report_dataGridView
            // 
            report_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            report_dataGridView.Location = new Point(3, 3);
            report_dataGridView.Name = "report_dataGridView";
            report_dataGridView.Size = new Size(923, 573);
            report_dataGridView.TabIndex = 0;
            // 
            // printReport
            // 
            printReport.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            printReport.Location = new Point(279, 582);
            printReport.Name = "printReport";
            printReport.Size = new Size(298, 47);
            printReport.TabIndex = 1;
            printReport.Text = "Друк";
            printReport.UseVisualStyleBackColor = true;
            printReport.Click += printReport_Click;
            // 
            // reportAllDiagnosisForPatients
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(printReport);
            Controls.Add(report_dataGridView);
            Name = "reportAllDiagnosisForPatients";
            Size = new Size(929, 644);
            ((System.ComponentModel.ISupportInitialize)report_dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView report_dataGridView;
        private Button printReport;
    }
}
