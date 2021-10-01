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
    public partial class frmCarros : Form
    {
        public frmCarros()
        {
            InitializeComponent();
        }

        private void frmCarros_Load(object sender, EventArgs e)
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
                        string strSql = $"insert into tbCarros(modelo, marca, placa, ano, valorDiaria, cor, carroStatus) values ('{txtModelo.Text}', '{txtMarca.Text}', '{txtPlaca.Text}', '{txtAno.Text}', {Convert.ToDouble(txtValorDiaria.Text)}, '{txtCor.Text}', {1});";
                        comandoSql = new SqlCommand(strSql, conn);
                        comandoSql.ExecuteNonQuery();

                        MessageBox.Show("Cadastrado com sucesso!");

                        LimparCampos();
                        DesabilitarCampos();
                        btnNovo.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            Conexao.FecharConexao();
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
                        string modelo = txtModelo.Text;
                        string marca = txtMarca.Text;
                        string placa = txtPlaca.Text;
                        string ano = txtAno.Text;
                        double diaria = Convert.ToDouble(txtValorDiaria.Text);
                        string cor = txtCor.Text;

                        string strSql = $"update tbCarros set modelo = '{modelo}', marca = '{marca}', placa = '{placa}', ano = '{ano}', valorDiaria = {diaria}, cor = '{cor}' where idCarro = {id};";

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
                string strSqlVerifica = $"select carroStatus from tbCarros where idCarro = {id};";

                comandoSql = new SqlCommand(strSqlVerifica, conn);
                SqlDataReader dataReader = comandoSql.ExecuteReader();

                dataReader.Read();
                int carroStatus = Convert.ToInt32(dataReader["carroStatus"]);
                dataReader.Close();

                if (carroStatus == 1)
                {
                    if (DialogResult.OK == MessageBox.Show("Tem certeza que deseja excluir?", "Excluir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                    {
                        string strSql = $"delete from tbCarros where idCarro = {id};";
                        comandoSql = new SqlCommand(strSql, conn);

                        comandoSql.ExecuteNonQuery();
                        MessageBox.Show("Removido com sucesso");
                        LimparCampos();
                        DesabilitarCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Não é possivel remover um carro que está alugado.");
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            DesabilitarCampos();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void dgvCarros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAlterar.Enabled = true;
            btnRemover.Enabled = true;
            btnCancelar.Enabled = true;
            btnLimpar.Enabled = false;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = false;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCarros.Rows[e.RowIndex];
                lblId.Text = row.Cells[0].Value.ToString();
                txtModelo.Text = row.Cells[1].Value.ToString();
                txtMarca.Text = row.Cells[2].Value.ToString();
                txtPlaca.Text = row.Cells[3].Value.ToString();
                txtAno.Text = row.Cells[4].Value.ToString();
                txtValorDiaria.Text = row.Cells[5].Value.ToString();
                txtCor.Text = row.Cells[6].Value.ToString();
            }
            HabilitarCampos();
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
                    comandoSql.CommandText = $"select * from tbCarros;";
                }
                else
                {
                    comandoSql.CommandText = $"select * from tbCarros where modelo like('%{txtBuscar.Text}%') or modelo like('%{txtBuscar.Text}%') or placa like('%{txtBuscar.Text}%') or ano like('%{txtBuscar.Text}%') or cor like('%{txtBuscar.Text}%');";
                }
                da.SelectCommand = comandoSql;
                da.Fill(dt);

                dgvCarros.DataSource = dt;
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
            txtModelo.Enabled = false;
            txtMarca.Enabled = false;
            txtPlaca.Enabled = false;
            txtAno.Enabled = false;
            txtValorDiaria.Enabled = false;
            txtCor.Enabled = false;
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
            txtModelo.Enabled = true;
            txtMarca.Enabled = true;
            txtPlaca.Enabled = true;
            txtAno.Enabled = true;
            txtValorDiaria.Enabled = true;
            txtCor.Enabled = true;

            txtModelo.Focus();
        }

        private bool VerificaCampos()
        {
            if (txtModelo.Text == "")
            {
                MessageBox.Show("Modelo é obrigatório.");
                txtModelo.Focus();
                return false;
            }
            else if (txtMarca.Text == "")
            {
                MessageBox.Show("Marca é obrigatório.");
                txtMarca.Focus();
                return false;
            }
            else if (txtAno.Text == "")
            {
                MessageBox.Show("Ano é obrigatório.");
                txtAno.Focus();
                return false;
            }
            else if (txtPlaca.Text == "")
            {
                MessageBox.Show("Placa é obrigatório.");
                txtPlaca.Focus();
                return false;
            }
            else if (txtValorDiaria.Text == "")
            {
                MessageBox.Show("Diária é obrigatório.");
                txtValorDiaria.Focus();
                return false;
            }
            else if (txtCor.Text == "")
            {
                MessageBox.Show("Cor é obrigatório.");
                txtCor.Focus();
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
