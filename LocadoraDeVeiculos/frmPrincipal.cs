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
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            panelLogin.BringToFront();
            txtLogin.Focus();
        }

        private void btnLogar_Click(object sender, EventArgs e)
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
                    comandoSql.CommandText = $"select tbFuncionarios.idFuncionario, tbFuncionarios.nomeFuncionario, tbFuncionarios.funcLogin, tbFuncionarios.funcSenha, tbCargos.nomeCargo from tbFuncionarios inner join tbCargos on tbFuncionarios.idCargo = tbCargos.idCargo where funcLogin = ('{txtLogin.Text}') and funcSenha = ('{txtSenha.Text}');";

                    using (var reader = comandoSql.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Funcionario.idFuncionario = reader.GetInt32(0);
                            Funcionario.nomeFuncionario = reader.GetString(1);
                            Funcionario.funcLogin = reader.GetString(2);
                            Funcionario.funcSenha = reader.GetString(3);
                            Funcionario.cargo = reader.GetString(4);

                            MessageBox.Show("Sucecsso");
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
