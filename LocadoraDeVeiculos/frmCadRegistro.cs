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
    public partial class frmCadRegistro : Form
    {
        public frmCadRegistro()
        {
            InitializeComponent();
        }

        private void frmCadRegistro_Load(object sender, EventArgs e)
        {
            DesabilitarCampos();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            LimparCampos();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            txtBuscar.Enabled = true;
            btnVeiculo.Enabled = false;
            btnSalvar.Enabled = false;
            lblBusca.Text = "Selecione um cliente";
        }

        private void btnVeiculo_Click(object sender, EventArgs e)
        {
            txtBuscar.Enabled = true;
            btnCliente.Enabled = false;
            btnSalvar.Enabled = false;
            lblBusca.Text = "Selecione um veículo";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            DesabilitarCampos();
            lblBusca.Text = "";
        }

        private void dgvRegistros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnCliente.Enabled)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvRegistros.Rows[e.RowIndex];
                    lblIdCliente.Text = row.Cells[0].Value.ToString();
                    txtNomeCliente.Text = row.Cells[1].Value.ToString();
                    txtCpfCliente.Text = row.Cells[3].Value.ToString();
                }
            }
            else
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvRegistros.Rows[e.RowIndex];
                    lblIdVeiculo.Text = row.Cells[0].Value.ToString();
                    txtModeloVeiculo.Text = row.Cells[1].Value.ToString();
                    txtPlaca.Text = row.Cells[3].Value.ToString();
                }
            }
            HabilitarCampos();
        }

        private void DesabilitarCampos()
        {
            btnNovo.Enabled = true;
            btnCancelar.Enabled = false;
            btnSalvar.Enabled = false;
            btnCliente.Enabled = false;
            btnVeiculo.Enabled = false;
            dtpInicio.Enabled = false;
            txtBuscar.Enabled = false;

            btnNovo.Focus();
        }

        private void HabilitarCampos()
        {
            btnSalvar.Enabled = true;
            btnCliente.Enabled = true;
            btnVeiculo.Enabled = true;
            btnCancelar.Enabled = true;
            dtpInicio.Enabled = true;
            btnNovo.Enabled = false;
            btnCliente.Focus();
        }

        private void LimparCampos()
        {
            txtCpfCliente.Text = "";
            txtNomeCliente.Text = "";
            txtModeloVeiculo.Text = "";
            txtPlaca.Text = "";
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
                if (btnVeiculo.Enabled)
                {
                    comandoSql.CommandText = $"select * from tbCarros where carroStatus = 1 and (modelo like('%{txtBuscar.Text}%') or modelo like('%{txtBuscar.Text}%') or placa like('%{txtBuscar.Text}%') or ano like('%{txtBuscar.Text}%') or cor like('%{txtBuscar.Text}%'));";
                }
                else
                {
                    comandoSql.CommandText = $"select * from tbClientes where nomeCliente like('%{txtBuscar.Text}%') or cpf like('%{txtBuscar.Text}%') or telefone like('%{txtBuscar.Text}%') or email like('%{txtBuscar.Text}%');";
                }

                da.SelectCommand = comandoSql;
                da.Fill(dt);

                dgvRegistros.DataSource = dt;
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Conexao.ObterConexao();
            SqlCommand insert;
            SqlCommand updateCar;

            if (conn == null)
            {
                MessageBox.Show("Não foi possível obter a conexao.");
            }
            else
            {
                if (txtCpfCliente.Text == "" || txtNomeCliente.Text == "" || txtPlaca.Text == "" || txtModeloVeiculo.Text == "")
                {
                    MessageBox.Show("Tods campos são obrigatórios");
                    Conexao.FecharConexao();
                }
                else
                {
                    try
                    {
                        string strInsert = $"insert into tbRegistrosDeAluguel(idClienteFK, idFuncionarioFK, idCarroFK, dataInicio, idAluguelStatusFK) values ({Convert.ToInt32(lblIdCliente.Text)}, {Funcionario.idFuncionario}, {Convert.ToInt32(lblIdVeiculo.Text)}, '{dtpInicio.Value}', {2});";
                        insert = new SqlCommand(strInsert, conn);
                        insert.ExecuteNonQuery();

                        string strUpdateCar = $"update tbCarros set carroStatus = {0} where idCarro = {Convert.ToInt32(lblIdVeiculo.Text)};";
                        updateCar = new SqlCommand(strUpdateCar, conn);
                        updateCar.ExecuteNonQuery();

                        MessageBox.Show("Cadastrado com sucesso!");
                        LimparCampos();
                        DesabilitarCampos();
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
            }
        }
    }
}
