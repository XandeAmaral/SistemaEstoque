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
    public partial class FCrudUsuario : Form
    {
        Validacoes validacoes;

        private void txtNome_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtNome.Text.Length > 0)
            {
                if (validacoes.ApenasLetras(this.txtNome.Text.ToString()[this.txtNome.Text.Length - 1]))
                {
                    MessageBox.Show("So pode escrever letras.");
                    this.txtNome.Clear();
                    this.txtNome.Focus();
                }
            }
        }
        private void txtNome_Leave(object sender, EventArgs e)
        {
            string frase = this.txtNome.Text.Trim();
            string[] palavras = frase.Split(' ');
            string login = palavras[0] + " " + palavras[palavras.Length - 1];
            this.txtLogin.Text = login;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Usuario Us;

            try
            {
                if (this.TestarElementos() == 0)
                {
                    if (this.txtSenha.Text.Equals(this.txtConfirmarSenha.Text))
                    {

                        Us = new Usuario();

                        Us.setnome(this.txtNome.Text);
                        Us.setLogin(this.txtLogin.Text);
                        Us.setEmail(this.txtEmail.Text);
                        Us.setsenha(this.txtSenha.Text);
                        if (this.chkAdminstrador.Checked) Us.setAdministrador(true);
                        else Us.setAdministrador(false);

                        Us.cadastrar();

                        this.Limpar();

                        MessageBox.Show("Cadastrado com Sucesso");
                    }
                    else { MessageBox.Show("Senhas nao coincidem"); this.txtSenha.Focus(); }
                }
                else { MessageBox.Show("Prencha todos os campos"); this.txtNome.Focus(); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {

        }


        private void Limpar()
        {// limpa os elementos da tela
            this.txtNome.Clear();
            this.txtLogin.Clear();
            this.txtEmail.Clear();
            this.txtSenha.Clear();
            this.txtConfirmarSenha.Clear();
            this.chkAdminstrador.Checked = false;
            this.txtNome.Focus();
        }

        private int TestarElementos()
        {// testa para ver se todos os elementos tem valor
            int aux = 1;
            Validacoes Va;

            try
            {
                Va = new Validacoes();

                aux += Va.NaoVazio(this.txtNome.Text);
                aux += Va.NaoVazio(this.txtLogin.Text);
                aux += Va.NaoVazio(this.txtEmail.Text);
                aux += Va.NaoVazio(this.txtSenha.Text);
                aux += Va.NaoVazio(this.txtConfirmarSenha.Text);

                return aux;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return aux; }

        }
    }
}
