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
    public partial class frmPendentes : Form
    {
        public frmPendentes()
        {
            InitializeComponent();
        }

        private void frmPendentes_Load(object sender, EventArgs e)
        {
            btnFinalizar.Enabled = false;
            SqlConnection conn = Conexao.ObterConexao();
            SqlCommand comandoSql = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            comandoSql.Connection = conn;

            try
            {
                comandoSql.CommandText = $"select * from tbRegistrosDeAluguel where idAluguelStatusFK = {2};";

                da.SelectCommand = comandoSql;
                da.Fill(dt);

                dgvPendentes.DataSource = dt;
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

        private void dgvPendentes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPendentes.Rows[e.RowIndex];
                lblId.Text = row.Cells[0].Value.ToString();
                lblIdCliente.Text = row.Cells[1].Value.ToString();
                lblIdVeiculo.Text = row.Cells[3].Value.ToString();
            }
            btnFinalizar.Enabled = true;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Conexao.ObterConexao();
            SqlCommand updateRegistro;
            SqlCommand updateCarro;
            SqlCommand selectDataInicial;

            try
            {
                if (lblId.Text == "")
                {
                    MessageBox.Show("Informe o registro.");
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("Tem certeza que deseja finalizar?", "Alterar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                    {
                        string strUpdateRegistro = $"update tbRegistrosDeAluguel set dataFim = '{dtpFim.Value}', idAluguelStatusFK = {1} where idAluguel = {Convert.ToInt32(lblId.Text)};";
                        updateRegistro = new SqlCommand(strUpdateRegistro, conn);

                        string strUpdateCarro = $"update tbCarros set carroStatus = {1} where idCarro = {Convert.ToInt32(lblIdVeiculo.Text)};";
                        updateCarro = new SqlCommand(strUpdateCarro, conn);

                        updateCarro.ExecuteNonQuery();
                        updateRegistro.ExecuteNonQuery();

                        MessageBox.Show("Finalizado com sucesso");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Conexao.FecharConexao();
            }
        }
    }
}