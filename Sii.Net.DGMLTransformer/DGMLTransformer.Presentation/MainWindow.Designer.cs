namespace DGMLTransformer.Presentation
{
    partial class MainWindow
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DgmlSelectorPanel = new System.Windows.Forms.Panel();
            this.DgmlFiltersPanel = new System.Windows.Forms.Panel();
            this.DgmlGeneratorPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.DgmlSelectorPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DgmlFiltersPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DgmlGeneratorPanel, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.43038F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.56962F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(383, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // DgmlSelectorPanel
            // 
            this.DgmlSelectorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgmlSelectorPanel.Location = new System.Drawing.Point(3, 3);
            this.DgmlSelectorPanel.Name = "DgmlSelectorPanel";
            this.DgmlSelectorPanel.Size = new System.Drawing.Size(377, 51);
            this.DgmlSelectorPanel.TabIndex = 0;
            // 
            // DgmlFiltersPanel
            // 
            this.DgmlFiltersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgmlFiltersPanel.Location = new System.Drawing.Point(3, 60);
            this.DgmlFiltersPanel.Name = "DgmlFiltersPanel";
            this.DgmlFiltersPanel.Size = new System.Drawing.Size(377, 332);
            this.DgmlFiltersPanel.TabIndex = 1;
            // 
            // DgmlGeneratorPanel
            // 
            this.DgmlGeneratorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgmlGeneratorPanel.Location = new System.Drawing.Point(3, 398);
            this.DgmlGeneratorPanel.Name = "DgmlGeneratorPanel";
            this.DgmlGeneratorPanel.Size = new System.Drawing.Size(377, 49);
            this.DgmlGeneratorPanel.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel DgmlSelectorPanel;
        private System.Windows.Forms.Panel DgmlFiltersPanel;
        private System.Windows.Forms.Panel DgmlGeneratorPanel;
    }
}