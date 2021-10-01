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
    }
}
