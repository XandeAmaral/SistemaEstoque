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
    public partial class FCrudFornecedor : Form
    {
        internal Validacoes Va;
        public readonly Usuario UsLogado; //objeto do Usuario Logado
        internal int codFornecedor = 0; // salvar o cod do Fornecedor selecionado do DGV

        public FCrudFornecedor()
        {
            InitializeComponent();
            mostrar();
        }
        public FCrudFornecedor(Usuario usuario)
        {
            InitializeComponent();
            UsLogado = usuario;
            mostrar();
        }
        private void FCrudFornecedor_Load(object sender, EventArgs e)
        {
            this.lblUsuario.Text = UsLogado.nome;
            this.txtNome.MaxLength = 50;
            this.txtCnpj.MaxLength = 16;
            this.txtTelefone.MaxLength = 17;
            this.txtEmail.MaxLength = 50;
        }
        private void mostrar() // mostra as pessoas da base no dgv
        {
            Fornecedor Fo;
            try
            {
                Fo = new Fornecedor();
                this.dgvFornecedor.DataSource = Fo.listar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void txtNome_KeyUp(object sender, KeyEventArgs e)
        {
            Fornecedor Fo;
            try
            {
                Fo = new Fornecedor();
                if (this.txtNome.Text.Trim().Length > 0)
                    this.dgvFornecedor.DataSource = Fo.buscaNome(this.txtNome.Text.Trim());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void txtNome_Leave(object sender, EventArgs e)
        {
            Fornecedor Fo;
            try
            {
                Fo = new Fornecedor();
                if (this.txtNome.Text.Trim().Length == 0)
                    this.dgvFornecedor.DataSource = Fo.listar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void limpar()
        {
            this.txtNome.Clear();
            this.txtEmail.Clear();
            this.txtCnpj.Clear();
            this.txtTelefone.Clear();

            this.txtNome.Focus(); // volta o foco pro textbox
        }
        private int TestarElementos()
        {// testa para ver se todos os elementos tem valor
            int aux = 0;
            Validacoes Va;

            try
            {
                Va = new Validacoes();

                aux += Va.NaoVazio(this.txtNome.Text);
                aux += Va.NaoVazio(this.txtEmail.Text);
                aux += Va.NaoVazio(this.txtCnpj.Text);
                aux += Va.NaoVazio(this.txtTelefone.Text);

                return aux;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return aux; }

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Fornecedor Fo;
            try
            {
                Fo = new Fornecedor();
                if (TestarElementos() == 0)
                {
                    Fo.setNome(this.txtNome.Text.Trim());
                    Fo.setEmail(this.txtEmail.Text.Trim());
                    Fo.setCnpj(this.txtCnpj.Text.Trim());
                    Fo.setTelefone(this.txtTelefone.Text.Trim());

                    Fo.cadastrar(); // função da classe Fornecedor

                    limpar();

                    MessageBox.Show("Cadastrado com sucesso"); // mostra uma mensagem na tela
                    mostrar();
                }
                else MessageBox.Show("Preencha todos os campos");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Fornecedor Fo;
            try
            {
                Fo = new Fornecedor();
                if (codFornecedor != 0)
                {
                    if (TestarElementos() == 0)
                    {
                        Fo.setNome(this.txtNome.Text.Trim());
                        Fo.setEmail(this.txtEmail.Text.Trim());
                        Fo.setCnpj(this.txtCnpj.Text.Trim());
                        Fo.setTelefone(this.txtTelefone.Text.Trim());

                        Fo.setCodigo(this.codFornecedor);

                        Fo.alterar();

                        limpar();

                        MessageBox.Show("Alterado com sucesso");
                        mostrar();
                        codFornecedor = 0;
                    }
                    else MessageBox.Show("Preencha todos os campos");
                }
                else MessageBox.Show("Antes e preciso selecionar um fornecedor");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void btnRemover_Click(object sender, EventArgs e)
        {
            Fornecedor Fo;
            try
            {
                Fo = new Fornecedor();
                if (codFornecedor != 0)
                {
                    Fo.setCodigo(this.codFornecedor);

                    Fo.remover();

                    limpar();

                    MessageBox.Show("Removido com sucesso");
                    mostrar();
                    codFornecedor = 0;
                }
                else MessageBox.Show("Antes e preciso selecionar um fornecedor");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void dgvFornecedor_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int i = this.dgvFornecedor.SelectedCells[0].RowIndex;
                if ((i != -1) && (i != this.dgvFornecedor.RowCount - 1))
                {
                    this.codFornecedor = Convert.ToInt32(this.dgvFornecedor.Rows[i].Cells[0].Value);
                    this.txtNome.Text = this.dgvFornecedor.Rows[i].Cells[1].Value.ToString();
                    this.txtCnpj.Text = this.dgvFornecedor.Rows[i].Cells[2].Value.ToString();
                    this.txtEmail.Text = this.dgvFornecedor.Rows[i].Cells[3].Value.ToString();
                    this.txtTelefone.Text = this.dgvFornecedor.Rows[i].Cells[4].Value.ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
