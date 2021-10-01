
namespace LocadoraDeVeiculos
{
    partial class frmFinalizados
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
            this.dgvFinalizados = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinalizados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFinalizados
            // 
            this.dgvFinalizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFinalizados.Location = new System.Drawing.Point(12, 225);
            this.dgvFinalizados.Name = "dgvFinalizados";
            this.dgvFinalizados.Size = new System.Drawing.Size(546, 209);
            this.dgvFinalizados.TabIndex = 0;
            // 
            // frmFinalizados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 446);
            this.Controls.Add(this.dgvFinalizados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFinalizados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFinalizados";
            this.Load += new System.EventHandler(this.frmFinalizados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinalizados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFinalizados;
    }
}