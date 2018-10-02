namespace DGMLTransformer.Presentation.UserControls
{
    partial class DgmlSelector
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
            this.DgmlSelectorButton = new System.Windows.Forms.Button();
            this.SelectedDgmlName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DgmlSelectorButton
            // 
            this.DgmlSelectorButton.Location = new System.Drawing.Point(21, 15);
            this.DgmlSelectorButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DgmlSelectorButton.Name = "DgmlSelectorButton";
            this.DgmlSelectorButton.Size = new System.Drawing.Size(148, 41);
            this.DgmlSelectorButton.TabIndex = 0;
            this.DgmlSelectorButton.Text = "Select DGML";
            this.DgmlSelectorButton.UseVisualStyleBackColor = true;
            this.DgmlSelectorButton.Click += new System.EventHandler(this.DgmlSelectorButton_Click);
            // 
            // SelectedDgmlName
            // 
            this.SelectedDgmlName.AutoSize = true;
            this.SelectedDgmlName.Location = new System.Drawing.Point(208, 27);
            this.SelectedDgmlName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SelectedDgmlName.Name = "SelectedDgmlName";
            this.SelectedDgmlName.Size = new System.Drawing.Size(210, 17);
            this.SelectedDgmlName.TabIndex = 1;
            this.SelectedDgmlName.Text = "Aucun fichier DGML sélectionné";
            // 
            // DgmlSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SelectedDgmlName);
            this.Controls.Add(this.DgmlSelectorButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DgmlSelector";
            this.Size = new System.Drawing.Size(1137, 68);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DgmlSelectorButton;
        private System.Windows.Forms.Label SelectedDgmlName;
    }
}
