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
        internal Validacoes Va;
        public readonly Usuario UsLogado; //objeto do Usuario Logado

        public FCrudUsuario()
        {
            InitializeComponent();
        }
        public FCrudUsuario(Usuario usuario)
        {
            InitializeComponent();
            UsLogado = usuario; // recebe o UsLogado
        }
        private void FCrudUsuario_Load(object sender, EventArgs e) // coloca o nome do UsLogado
        {
            lblUsuario.Text = UsLogado.nome;
        }
        private void txtNome_KeyUp(object sender, KeyEventArgs e) // so permite letras
        {
            if (this.txtNome.Text.Length > 0)
            {
                //if (validacoes.ApenasLetras(this.txtNome.Text.ToString()))
                if (Va.ApenasLetras(this.txtNome.Text.ToString()[this.txtNome.Text.Length - 1]))
                {
                    MessageBox.Show("So pode escrever letras.");
                    this.txtNome.Focus();
                }
            }
        }
        private void txtNome_Leave(object sender, EventArgs e) // ja cria a frase do login
        {
            string frase = this.txtNome.Text.Trim().ToLower();
            string[] palavras = frase.Split(' ');
            string login = palavras[0][0] + palavras[palavras.Length - 1];
            this.txtLogin.Text = login;
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
            int aux = 0;

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

                        Us.setNome(this.txtNome.Text);
                        Us.setLogin(this.txtLogin.Text);
                        Us.setEmail(this.txtEmail.Text);
                        Us.setSenha(this.txtSenha.Text);
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
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
