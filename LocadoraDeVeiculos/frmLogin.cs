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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        public void frmLogin_Load(object sender, EventArgs e)
        {
            txtLogin.Focus();
        }

        public void btnLogar_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == "" || txtSenha.Text == "")
            {
                MessageBox.Show("Preencha todos os campos.");
                if (txtLogin.Text == "")
                {
                    txtLogin.Focus();
                }
                else
                {
                    txtSenha.Focus();
                }
            }
            else
            {
                try
                {
                    SqlConnection conn = Conexao.ObterConexao();
                    SqlCommand comandoSql = new SqlCommand();

                    comandoSql.Connection = conn;
                    comandoSql.CommandText = $"select tbFuncionarios.idFuncionario, tbFuncionarios.nomeFuncionario, tbFuncionarios.funcLogin, tbFuncionarios.funcSenha, tbFuncionarios.idCargo, tbCargos.nomeCargo from tbFuncionarios inner join tbCargos on tbFuncionarios.idCargo = tbCargos.idCargo where funcLogin = ('{txtLogin.Text}') and funcSenha = ('{txtSenha.Text}');";

                    using (var reader = comandoSql.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Funcionario.idFuncionario = reader.GetInt32(0);
                            Funcionario.nomeFuncionario = reader.GetString(1);
                            Funcionario.funcLogin = reader.GetString(2);
                            Funcionario.funcSenha = reader.GetString(3);
                            Funcionario.idCargo = reader.GetInt32(4);
                            Funcionario.cargo = reader.GetString(5);

                            frmPrincipal principal = new frmPrincipal();
                            principal.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Login ou senha inválidos");
                        }
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
        }
    }
}
