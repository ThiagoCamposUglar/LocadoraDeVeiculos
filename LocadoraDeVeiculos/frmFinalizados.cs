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
    public partial class frmFinalizados : Form
    {
        public frmFinalizados()
        {
            InitializeComponent();
        }

        private void frmFinalizados_Load(object sender, EventArgs e)
        {
            SqlConnection conn = Conexao.ObterConexao();
            SqlCommand comandoSql;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                string strSql = $"select * from tbRegistrosDeAluguel where idAluguelStatusFK = 1;";

                comandoSql = new SqlCommand(strSql, conn);
                da.SelectCommand = comandoSql;
                da.Fill(dt);

                dgvFinalizados.DataSource = dt;
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
