using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos
{
    public partial class frmPrincipal : Form
    {

        Form form;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            btnClientes.Width = panelNavBar.Width;
            btnCarros.Width = panelNavBar.Width;
            btnCadRegistro.Width = panelNavBar.Width;
            btnFuncionarios.Width = panelNavBar.Width;
            btnPendentes.Width = panelNavBar.Width;
            lblNome.Text = Funcionario.nomeFuncionario;
            lblCargo.Text = Funcionario.cargo;
            if (Funcionario.idCargo != 1)
            {
                btnFuncionarios.Enabled = false;
                btnCarros.Enabled = false;

            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            if (form == null)
            {
                form = new frmCliente();
            }
            else
            {
                form.Close();
                form.Dispose();
                form = new frmCliente();
            }
            form.MdiParent = this;
            form.Show();
        }

        private void btnCarros_Click(object sender, EventArgs e)
        {
            if (form == null)
            {
                form = new frmCarros();
            }
            else
            {
                form.Close();
                form.Dispose();
                form = new frmCarros();
            }
            form.MdiParent = this;
            form.Show();
        }

        private void btnRegistros_Click(object sender, EventArgs e)
        {
            if (form == null)
            {
                form = new frmCadRegistro();
            }
            else
            {
                form.Close();
                form.Dispose();
                form = new frmCadRegistro();
            }
            form.MdiParent = this;
            form.Show();
        }

        private void btnPendentes_Click(object sender, EventArgs e)
        {
            if (form == null)
            {
                form = new frmPendentes();
            }
            else
            {
                form.Close();
                form.Dispose();
                form = new frmPendentes();
            }
            form.MdiParent = this;
            form.Show();
        }

        private void btnFinalizados_Click(object sender, EventArgs e)
        {
            if (form == null)
            {
                form = new frmFinalizados();
            }
            else
            {
                form.Close();
                form.Dispose();
                form = new frmFinalizados();
            }
            form.MdiParent = this;
            form.Show();
        }
    }
}
