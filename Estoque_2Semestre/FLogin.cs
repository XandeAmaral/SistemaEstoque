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

                    if (Us.fazerLogin(login, senha))
                    {  // funcao de login

                        MessageBox.Show("Sucesso no Login");
                        FHome f = new FHome();

                        f.nome = Us.nome;
                        f.admin = Us.administrador;

                        this.Hide();
                        f.ShowDialog();
                        this.Close();
                    }
                    else MessageBox.Show("Usuario ou senha errados.");
                }
                else { MessageBox.Show("Preencha todos os campos."); txtNome.Focus(); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private int TestarElementos()
        {// testa para ver se todos os elementos tem valor
            int aux = 1;
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
    }
}
