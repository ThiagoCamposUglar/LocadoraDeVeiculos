
namespace LocadoraDeVeiculos
{
    partial class frmPrincipal
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
            this.panelNavBar = new System.Windows.Forms.Panel();
            this.btnClientes = new System.Windows.Forms.Button();
            this.lblCargo = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRegistros = new System.Windows.Forms.Button();
            this.btnCarros = new System.Windows.Forms.Button();
            this.btnFuncionarios = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelNavBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelNavBar
            // 
            this.panelNavBar.Controls.Add(this.btnFuncionarios);
            this.panelNavBar.Controls.Add(this.btnCarros);
            this.panelNavBar.Controls.Add(this.btnRegistros);
            this.panelNavBar.Controls.Add(this.btnClientes);
            this.panelNavBar.Controls.Add(this.label2);
            this.panelNavBar.Controls.Add(this.lblCargo);
            this.panelNavBar.Controls.Add(this.label1);
            this.panelNavBar.Controls.Add(this.lblNome);
            this.panelNavBar.Controls.Add(this.pictureBox1);
            this.panelNavBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelNavBar.Location = new System.Drawing.Point(0, 0);
            this.panelNavBar.Name = "panelNavBar";
            this.panelNavBar.Size = new System.Drawing.Size(226, 450);
            this.panelNavBar.TabIndex = 3;
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.Location = new System.Drawing.Point(3, 128);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(223, 44);
            this.btnClientes.TabIndex = 2;
            this.btnClientes.Text = "CLIENTES";
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargo.ForeColor = System.Drawing.Color.White;
            this.lblCargo.Location = new System.Drawing.Point(101, 74);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(45, 16);
            this.lblCargo.TabIndex = 1;
            this.lblCargo.Text = "label1";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.ForeColor = System.Drawing.Color.White;
            this.lblNome.Location = new System.Drawing.Point(101, 30);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(45, 16);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(14, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnRegistros
            // 
            this.btnRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnRegistros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistros.FlatAppearance.BorderSize = 0;
            this.btnRegistros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnRegistros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistros.ForeColor = System.Drawing.Color.White;
            this.btnRegistros.Location = new System.Drawing.Point(3, 178);
            this.btnRegistros.Name = "btnRegistros";
            this.btnRegistros.Size = new System.Drawing.Size(223, 44);
            this.btnRegistros.TabIndex = 2;
            this.btnRegistros.Text = "REGISTROS";
            this.btnRegistros.UseVisualStyleBackColor = false;
            this.btnRegistros.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnCarros
            // 
            this.btnCarros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnCarros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCarros.FlatAppearance.BorderSize = 0;
            this.btnCarros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCarros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarros.ForeColor = System.Drawing.Color.White;
            this.btnCarros.Location = new System.Drawing.Point(3, 228);
            this.btnCarros.Name = "btnCarros";
            this.btnCarros.Size = new System.Drawing.Size(223, 44);
            this.btnCarros.TabIndex = 2;
            this.btnCarros.Text = "VEÍCULOS";
            this.btnCarros.UseVisualStyleBackColor = false;
            this.btnCarros.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnFuncionarios
            // 
            this.btnFuncionarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.btnFuncionarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFuncionarios.FlatAppearance.BorderSize = 0;
            this.btnFuncionarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnFuncionarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFuncionarios.ForeColor = System.Drawing.Color.White;
            this.btnFuncionarios.Location = new System.Drawing.Point(3, 278);
            this.btnFuncionarios.Name = "btnFuncionarios";
            this.btnFuncionarios.Size = new System.Drawing.Size(223, 44);
            this.btnFuncionarios.TabIndex = 2;
            this.btnFuncionarios.Text = "FUNCIONÁRIOS";
            this.btnFuncionarios.UseVisualStyleBackColor = false;
            this.btnFuncionarios.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(101, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "NOME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(101, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "CARGO";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(45)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelNavBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.panelNavBar.ResumeLayout(false);
            this.panelNavBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNavBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnFuncionarios;
        private System.Windows.Forms.Button btnCarros;
        private System.Windows.Forms.Button btnRegistros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

