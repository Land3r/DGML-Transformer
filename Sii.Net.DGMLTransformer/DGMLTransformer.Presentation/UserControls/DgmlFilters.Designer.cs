namespace DGMLTransformer.Presentation.UserControls
{
    partial class DgmlFilters
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.DgmlCategoryCheckedListView = new System.Windows.Forms.ListView();
            this.CheckAll = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgmlCategoryCheckedListView
            // 
            this.DgmlCategoryCheckedListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgmlCategoryCheckedListView.Location = new System.Drawing.Point(3, 24);
            this.DgmlCategoryCheckedListView.Name = "DgmlCategoryCheckedListView";
            this.DgmlCategoryCheckedListView.Size = new System.Drawing.Size(319, 251);
            this.DgmlCategoryCheckedListView.TabIndex = 0;
            this.DgmlCategoryCheckedListView.UseCompatibleStateImageBehavior = false;
            this.DgmlCategoryCheckedListView.View = System.Windows.Forms.View.List;
            // 
            // CheckAll
            // 
            this.CheckAll.AutoSize = true;
            this.CheckAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckAll.Location = new System.Drawing.Point(3, 3);
            this.CheckAll.Name = "CheckAll";
            this.CheckAll.Size = new System.Drawing.Size(319, 15);
            this.CheckAll.TabIndex = 1;
            this.CheckAll.Text = "Check/uncheck all";
            this.CheckAll.UseVisualStyleBackColor = true;
            this.CheckAll.CheckedChanged += new System.EventHandler(this.CheckAll_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.DgmlCategoryCheckedListView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.CheckAll, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.553957F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.44604F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(325, 278);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // DgmlFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DgmlFilters";
            this.Size = new System.Drawing.Size(325, 278);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView DgmlCategoryCheckedListView;
        private System.Windows.Forms.CheckBox CheckAll;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
