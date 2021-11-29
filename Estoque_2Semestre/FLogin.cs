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
        public FLogin()
        {
            InitializeComponent();
        }

        private int TestarElementos()
        {// testa para ver se todos os elementos tem valor
            int aux = 0;
            Validacoes Va;

            try
            {
                Va = new Validacoes();

                aux += Va.NaoVazio(this.txtNome.Text);
                aux += Va.NaoVazio(this.txtSenha.Text);

                return aux;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return aux; }
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            Usuario Us;
            string login = txtNome.Text.Trim();
            string senha = txtSenha.Text.Trim();

            try
            {
                Us = new Usuario();

                if (this.TestarElementos() == 0)
                { // verifica se todos os campos estao preenchidos

                    Us = Us.fazerLogin(login, senha); // faz o login e ja alimenta o objeto com os dados

                    if (Us != null)
                    {  // funcao de login

                        MessageBox.Show("Sucesso no Login");
                        FHome f = new FHome(Us); // passa o Usuario Logado para os proximos Forms

                        this.Hide(); // esconde essa tela de Login
                        f.ShowDialog(); // Abre o Menu
                        this.Close(); // Caso o Menu feche o programa tambem fecha
                        // obs: da para fazer ele voltar a tela de login
                    }
                    else MessageBox.Show("Usuario ou senha errados.");
                }
                else { MessageBox.Show("Preencha todos os campos."); txtNome.Focus(); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
