using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque_2Semestre
{
    public partial class FLogin : Form
    {
        public string nomeUsuario;
        private string usuarioTeste = "Ale";
        private string senhaTeste = "12a";

        public FLogin()
        {
            nomeUsuario = "";
            InitializeComponent();
            // limpar o Login toda vez q voltar para essa tela.
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            string login = txtNome.Text.Trim();
            string senha = txtSenha.Text.Trim();
            string descr = "";

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha))
            {// valida se nao estao vazios
                MessageBox.Show("Digite um valor.");
                txtNome.Focus();
            }
            else
            {// faz o teste de acesso
                descr = fazerlogin(login, senha); // funcao de teste

                if (string.IsNullOrEmpty(descr))
                {
                    MessageBox.Show("Login com sucesso.");
                    FHome f = new FHome();
                    this.Hide();
                    f.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(descr);
                    txtNome.Focus();
                }
            }
        }

        private string fazerlogin(string login, string senha)
        {
            string descr="";

            if (login != usuarioTeste) { descr = "Usuario nao encontrado"; }
            else if (senha != senhaTeste) { descr = "Senha invalida"; }
            else descr = "";

            return descr;
        }
    }
}
