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
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            DesabilitarCampos();
            btnNovo.Focus();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            btnLimpar.Enabled = true;
            HabilitarCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Conexao.ObterConexao();
            SqlCommand comandoSql;

            if (conn == null)
            {
                MessageBox.Show("Não foi possível obter a conexao.");
            }
            else
            {
                if (VerificaCampos())
                {
                    try
                    {
                        string strSql = $"insert into tbClientes(nomeCliente, telefone, cpf, email) values ('{txtNome.Text}', '{txtTelefone.Text}', '{txtCpf.Text}', '{txtEmail.Text}');";
                        comandoSql = new SqlCommand(strSql, conn);
                        comandoSql.ExecuteNonQuery();

                        MessageBox.Show("Cadastrado com sucesso!");

                        LimparCampos();
                        DesabilitarCampos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            Conexao.FecharConexao();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            DesabilitarCampos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = Conexao.ObterConexao();
            SqlCommand comandoSql = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            comandoSql.Connection = conn;

            try
            {
                if (txtBuscar.Text == "")
                {
                    comandoSql.CommandText = $"select * from tbClientes;";
                }
                else
                {
                    comandoSql.CommandText = $"select * from tbClientes where nomeCliente like('%{txtBuscar.Text}%') or cpf like('%{txtBuscar.Text}%') or telefone like('%{txtBuscar.Text}%') or email like('%{txtBuscar.Text}%');";
                }
                da.SelectCommand = comandoSql;
                da.Fill(dt);

                dgvClientes.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conexao.FecharConexao();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAlterar.Enabled = true;
            btnRemover.Enabled = true;
            btnCancelar.Enabled = true;
            btnLimpar.Enabled = false;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = false;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvClientes.Rows[e.RowIndex];
                lblId.Text = row.Cells[0].Value.ToString();
                txtNome.Text = row.Cells[1].Value.ToString();
                txtTelefone.Text = row.Cells[2].Value.ToString();
                txtCpf.Text = row.Cells[3].Value.ToString();
                txtEmail.Text = row.Cells[4].Value.ToString();
            }
            HabilitarCampos();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Conexao.ObterConexao();
            SqlCommand comandoSql;

            if (VerificaCampos())
            {
                try
                {
                    if (DialogResult.OK == MessageBox.Show("Tem certeza que deseja alterar?", "Alterar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                    {
                        int id = Convert.ToInt32(lblId.Text);
                        string nome = txtNome.Text;
                        string email = txtEmail.Text;
                        string cpf = txtCpf.Text;
                        string telefone = txtTelefone.Text;

                        string strSql = $"update tbClientes set nomeCliente = '{nome}', email = '{email}', cpf = '{cpf}', telefone = '{telefone}' where idCliente = {id};";

                        comandoSql = new SqlCommand(strSql, conn);

                        comandoSql.ExecuteNonQuery();

                        MessageBox.Show("Dados Altereados com sucesso");

                        DesabilitarCampos();
                        LimparCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            Conexao.FecharConexao();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Conexao.ObterConexao();
            SqlCommand comandoSql;

            try
            {
                int id = Convert.ToInt32(lblId.Text);
                string strSql = $"delete from tbClientes where idCliente = {id};";

                if (DialogResult.OK == MessageBox.Show("Tem certeza que deseja excluir?", "Excluir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    comandoSql = new SqlCommand(strSql, conn);

                    comandoSql.ExecuteNonQuery();
                    MessageBox.Show("Removido com sucesso");
                    LimparCampos();
                    DesabilitarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conexao.FecharConexao();
            }
        }

        private void DesabilitarCampos()
        {
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            txtCpf.Enabled = false;
            txtTelefone.Enabled = false;
            btnAlterar.Enabled = false;
            btnCancelar.Enabled = false;
            btnRemover.Enabled = false;
            btnSalvar.Enabled = false;
            btnLimpar.Enabled = false;

            btnNovo.Enabled = true;
            btnNovo.Focus();
        }

        private void HabilitarCampos()
        {
            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            txtTelefone.Enabled = true;
            txtCpf.Enabled = true;

            txtNome.Focus();
        }

        private bool VerificaCampos()
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Nome é obrigatório.");
                txtNome.Focus();
                return false;
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Email é obrigatório.");
                txtEmail.Focus();
                return false;
            }
            else if (txtTelefone.Text == "")
            {
                MessageBox.Show("Telefone é obrigatório.");
                txtTelefone.Focus();
                return false;
            }
            else if (txtCpf.Text == "")
            {
                MessageBox.Show("CPF é obrigatório.");
                txtCpf.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void LimparCampos()
        {
            foreach (Control con in Controls.OfType<TextBox>())
            {
                con.Text = "";
            }
            foreach (Control con in Controls.OfType<MaskedTextBox>())
            {
                con.Text = "";
            }
            lblId.Text = "";
        }
    }
}
