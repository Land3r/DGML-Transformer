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
            this.DgmlCategoryCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // DgmlCategoryCheckedListBox
            // 
            this.DgmlCategoryCheckedListBox.CheckOnClick = true;
            this.DgmlCategoryCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgmlCategoryCheckedListBox.FormattingEnabled = true;
            this.DgmlCategoryCheckedListBox.Location = new System.Drawing.Point(0, 0);
            this.DgmlCategoryCheckedListBox.Margin = new System.Windows.Forms.Padding(4);
            this.DgmlCategoryCheckedListBox.Name = "DgmlCategoryCheckedListBox";
            this.DgmlCategoryCheckedListBox.Size = new System.Drawing.Size(433, 342);
            this.DgmlCategoryCheckedListBox.Sorted = true;
            this.DgmlCategoryCheckedListBox.TabIndex = 0;
            // 
            // DgmlFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DgmlCategoryCheckedListBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DgmlFilters";
            this.Size = new System.Drawing.Size(433, 342);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox DgmlCategoryCheckedListBox;
    }
}
