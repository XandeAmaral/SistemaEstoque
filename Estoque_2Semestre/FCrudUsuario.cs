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
        internal Validacoes Va = new Validacoes();
        public readonly Usuario UsLogado = new Usuario(); //objeto do Usuario Logado
        internal int codUsuario = 0;
        public FCrudUsuario()
        {
            InitializeComponent();
            mostrar();
            this.dgvUsuario.Columns.Add("codusuario", "Codigo Usuario");
            this.dgvUsuario.Columns.Add("nome", "Nome");
            this.dgvUsuario.Columns.Add("administrador", "Administrador");
            this.dgvUsuario.Columns.Add("login", "Login");
            this.dgvUsuario.Columns.Add("email", "Email");
        }
        public FCrudUsuario(Usuario usuario)
        {
            InitializeComponent();
            UsLogado = usuario; // recebe o UsLogado
            mostrar();
            this.dgvUsuario.Columns.Add("codusuario", "Codigo Usuario");
            this.dgvUsuario.Columns.Add("nome", "Nome");
            this.dgvUsuario.Columns.Add("administrador", "Administrador");
            this.dgvUsuario.Columns.Add("login", "Login");
            this.dgvUsuario.Columns.Add("email", "Email");
        }
        // Select codusuario, nome, administrador, login, email from usuario
        private void FCrudUsuario_Load(object sender, EventArgs e) // coloca o nome do UsLogado
        {
            this.lblUsuario.Text = UsLogado.nome;
            this.txtNome.MaxLength = 50;
            this.txtSenha.MaxLength = 20;
            this.txtConfirmarSenha.MaxLength = 20;
            this.txtLogin.MaxLength = 30;
            this.txtEmail.MaxLength = 50;            
        }
        private void txtNome_KeyUp(object sender, KeyEventArgs e) // so permite letras
        {
            Usuario Us;
            try
            {
                Us = new Usuario();
                string texto = txtNome.Text.ToString();

                if (this.txtNome.Text.Length > 0)
                {
                    //if (Va.ApenasLetras(texto) passa como uma string
                    if (Va.ApenasLetras(texto[texto.Length - 1])) // passa como char
                    {
                        texto = texto.Substring(0, texto.Length - 1);

                        this.txtNome.Text = texto;
                        MessageBox.Show("So pode escrever letras.");
                        this.txtNome.Focus();
                    }
                    else this.dgvUsuario.DataSource = Us.buscaNome(this.txtNome.Text.Trim());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void txtNome_Leave(object sender, EventArgs e) // ja cria a frase do login
        {
            string frase = this.txtNome.Text.Trim().ToLower();
            string[] palavras = frase.Split(' ');
            string login = palavras[0][0] + palavras[palavras.Length - 1];
            this.txtLogin.Text = login;
        }
        private void limpar()
        {// limpa os elementos da tela
            this.txtNome.Clear();
            this.txtLogin.Clear();
            this.txtEmail.Clear();
            this.txtSenha.Clear();
            this.txtConfirmarSenha.Clear();
            this.chkAdminstrador.Checked = false;
            this.txtNome.Focus();
        }
        private int testarElementos()
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
        private void mostrar() // mostra as pessoas da base no dgv
        {
            Usuario Us;
            try
            {
                Us = new Usuario();
                this.dgvUsuario.DataSource = Us.listar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Usuario Us;

            try
            {
                Us = new Usuario();

                if (this.testarElementos() == 0)
                {
                    if (this.txtSenha.Text.Equals(this.txtConfirmarSenha.Text))
                    {

                        Us.setNome(this.txtNome.Text);
                        Us.setLogin(this.txtLogin.Text);
                        Us.setEmail(this.txtEmail.Text);
                        Us.setSenha(this.txtSenha.Text);
                        if (this.chkAdminstrador.Checked) Us.setAdministrador(true);
                        else Us.setAdministrador(false);

                        Us.cadastrar();

                        this.limpar();

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
            Usuario Us;
            try
            {
                Us = new Usuario();
                if (codUsuario != 0)
                {
                    if (testarElementos() == 0)
                    {
                        if (this.txtSenha.Text.Equals(this.txtConfirmarSenha.Text))
                        {
                            Us.setNome(this.txtNome.Text);
                            Us.setLogin(this.txtLogin.Text);
                            Us.setEmail(this.txtEmail.Text);
                            Us.setSenha(this.txtSenha.Text);
                            if (this.chkAdminstrador.Checked) Us.setAdministrador(true);
                            else Us.setAdministrador(false);

                            Us.setCodigo(this.codUsuario);

                            Us.alterar();

                            limpar();

                            MessageBox.Show("Alterado com sucesso");
                            mostrar();
                            this.codUsuario = 0;
                        }
                        else { MessageBox.Show("Senhas nao coincidem"); this.txtSenha.Focus(); }
                    }
                    else MessageBox.Show("Preencha todos os campos");
                }
                else MessageBox.Show("Antes e preciso selecionar um usuario");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void btnRemover_Click(object sender, EventArgs e)
        {
            Usuario Us;
            try
            {
                Us = new Usuario();
                if (codUsuario != 0)
                {
                    Us.setCodigo(this.codUsuario);

                    Us.remover();

                    limpar();

                    MessageBox.Show("Removido com sucesso");
                    mostrar();
                    this.codUsuario = 0;
                }
                else MessageBox.Show("Antes e preciso selecionar um usuario");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvUsuario_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int i = this.dgvUsuario.SelectedCells[0].RowIndex;
                if ((i != -1) && (i != this.dgvUsuario.RowCount - 1))
                {
                    this.codUsuario = Convert.ToInt32(this.dgvUsuario.Rows[i].Cells[0].Value);
                    this.txtNome.Text = this.dgvUsuario.Rows[i].Cells[1].Value.ToString();
                    this.chkAdminstrador.Checked = Convert.ToBoolean(this.dgvUsuario.Rows[i].Cells[2].Value);
                    this.txtEmail.Text = this.dgvUsuario.Rows[i].Cells[3].Value.ToString();
                    this.txtLogin.Text = this.dgvUsuario.Rows[i].Cells[4].Value.ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
