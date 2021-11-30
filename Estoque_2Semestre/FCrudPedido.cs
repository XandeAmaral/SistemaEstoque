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
    public partial class FCrudPedido : Form
    {
        private Validacoes Va = new Validacoes();
        public readonly Usuario UsLogado = new Usuario(); 
        internal int codPedido = 0;
        internal int codPedidoMax = 0;
        internal int codFornecedor = 0;
        internal int codItem = 0;
        internal int qtde = 1;

        public FCrudPedido()
        {
            InitializeComponent();
            mostrar();
        }

        public FCrudPedido(Usuario usuario)
        {
            InitializeComponent();
            UsLogado = usuario;
            mostrar();
        }

        private void FCrudPedido_Load(object sender, EventArgs e)
        {
            Pedido Pe;
            try
            {
                Pe = new Pedido();
                this.lblUsuario.Text = UsLogado.nome;
                this.codPedidoMax = Pe.retornarMaiorCod();
                this.codPedido = this.codPedidoMax;
                this.txtNPedido.Text = codPedidoMax.ToString();
                this.txtStatus.MaxLength = 10;
                listaFornecedores();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void txtNPedido_TextChanged(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtNPedido.Text.Trim())))
            {
                if (Va.ApenasNumeros(txtNPedido.Text.ToString()[txtNPedido.Text.Length - 1]))
                {
                    MessageBox.Show("So pode escrever numero.");
                    txtNPedido.Clear();
                    txtNPedido.Focus();
                }
            }
        }
        private void txtCNPJ_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtCNPJ.Text.Trim())))
            {
                if (Va.ApenasNumeros(txtCNPJ.Text.ToString()[txtCNPJ.Text.Length - 1]))
                {
                    MessageBox.Show("So pode escrever numero.");
                    txtNPedido.Clear();
                    txtNPedido.Focus();
                }
            }
        }
        private void txtTelefone_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtTelefone.Text.Trim())))
            {
                if (Va.ApenasNumeros(txtTelefone.Text.ToString()[txtTelefone.Text.Length - 1]))
                {
                    MessageBox.Show("So pode escrever numero.");
                    txtNPedido.Clear();
                    txtNPedido.Focus();
                }
            }
        }
        private void txtValor_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtValor.Text.Trim())))
            {
                if (Va.ApenasNumeros(txtValor.Text.ToString()[txtValor.Text.Length - 1]))
                {
                    MessageBox.Show("So pode escrever numero.");
                    txtNPedido.Clear();
                    txtNPedido.Focus();
                }
            }
        }
        
        private void mostrar()
        {
            Pedido Pe;
            try
            {
                Pe = new Pedido();
                this.dgvPedido.DataSource = Pe.listar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void completarFornecedor(int cod)
        {
            Fornecedor Fo;
            DataTable tb;
            try
            {
                Fo = new Fornecedor();
                tb = new DataTable();

                tb = Fo.buscaCod(this.codFornecedor);
                if (tb != null)
                {
                    this.txtCNPJ.Text = tb.Rows[0][0].ToString();
                    this.txtEmail.Text = tb.Rows[0][1].ToString();
                    this.txtTelefone.Text = tb.Rows[0][2].ToString();

                    //cnpj, email, telefone from fornecedor
                }
                else MessageBox.Show("Falha ao buscar os dados do Fornecedor. \n Contate o suporte.");
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }

        private void limpar()
        {
            this.txtNPedido.Clear();
            this.txtCNPJ.Clear();
            this.txtEmail.Clear();
            this.txtTelefone.Clear();
            this.cmbFornecedor.Items.Clear();
            this.txtStatus.Clear();
            this.txtDescr.Clear();
        }
        private int testarElementos()
        {
            int aux = 0;

            try
            {
                Va = new Validacoes();

                aux += Va.NaoVazio(this.txtNPedido.Text);
                aux += Va.NaoVazio(this.txtCNPJ.Text);
                aux += Va.NaoVazio(this.txtEmail.Text);
                aux += Va.NaoVazio(this.txtTelefone.Text);
                aux += Va.NaoVazio(this.txtStatus.Text);
                aux += Va.NaoVazio(this.txtDescr.Text);
                aux += Va.NaoVazio(this.txtValor.Text);

                return aux;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return aux; }

        }
        private void listaFornecedores()
        {
            Fornecedor Fo;
            try
            {
                Fo = new Fornecedor();
                this.cmbFornecedor.DataSource = Fo.listarPorCod();
                this.cmbFornecedor.ValueMember = "codfornecedor";
                this.cmbFornecedor.DisplayMember = "nome";

                if (this.cmbFornecedor.Items.Count <= 0)
                {
                    MessageBox.Show("Nenhum fornecedor encontrado. \n Cadastre um fornecedor antes de continuar.");
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void cmbFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codFor = "0";

            if (this.cmbFornecedor.SelectedValue.ToString() != null)
            {
                codFor = this.cmbFornecedor.SelectedValue.ToString();
                foreach (char letra in codFor)
                {
                    if (letra >= '0' && letra <= '9')
                    { // se estiver dentro de 0 - 9
                        this.codFornecedor = Convert.ToInt32(codFor);
                        completarFornecedor(this.codFornecedor);
                    }
                }
            }
            else MessageBox.Show("Problema com o codFornecedor. \n Interrompa o processo e nos avise");            
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Pedido Pe;

            try
            {
                Pe = new Pedido();

                if (this.testarElementos() == 0)
                {
                    if ((this.codPedido != this.codPedidoMax) || (this.codPedidoMax == 0) && (this.codPedido == 0))
                    {
                        //codpedido
                        Pe.setcodUsuario(this.UsLogado.codigo);
                        //Pe.setcodItem(this.codItem);
                        Pe.setcodFornecedor(this.codFornecedor);
                        Pe.setqtde(this.qtde);
                        Pe.setvalor(this.txtValor.Text);
                        Pe.setdata(this.dtpPedido.Value) ;
                        Pe.setstatus(this.txtStatus.Text);
                        Pe.setdescr(this.txtDescr.Text);
                        // codpedido, codusuario, coditem, codfornecedor, qtde, valor, data, status, descr

                        Pe.cadastrar();

                        this.limpar();

                        MessageBox.Show("Cadastrado com Sucesso");
                    }
                    MessageBox.Show("Há um pedido selecionado, reinicie a tela");
                }
                else { MessageBox.Show("Prencha todos os campos"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Pedido Pe;
            try
            {
                Pe = new Pedido();
                if (codPedido != 0)
                {
                    if (testarElementos() == 0)
                    {
                        Pe.setcodUsuario(this.UsLogado.codigo);
                        //Pe.setcodItem(this.codItem);
                        Pe.setcodFornecedor(this.codFornecedor);
                        Pe.setqtde(this.qtde);
                        Pe.setvalor(this.txtValor.Text);
                        Pe.setdata(this.dtpPedido.Value);
                        Pe.setstatus(this.txtStatus.Text);
                        Pe.setdescr(this.txtDescr.Text);

                        Pe.setcodigo(this.codPedido);

                        Pe.alterar();

                        limpar();

                        MessageBox.Show("Alterado com sucesso");
                        mostrar();
                        this.codPedido = 0;
                    }
                    else MessageBox.Show("Preencha todos os campos");
                }
                else MessageBox.Show("Antes e preciso selecionar um pedido");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            Pedido Pe;
            try
            {
                Pe = new Pedido();
                if (codPedido != 0)
                {
                    Pe.setcodigo(this.codPedido);

                    Pe.remover();

                    limpar();

                    MessageBox.Show("Removido com sucesso");
                    mostrar();
                    this.codPedido = -1;
                }
                else MessageBox.Show("Antes e preciso selecionar um pedido");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dgvPedido_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                int i = this.dgvPedido.SelectedCells[0].RowIndex;
                if ((i != -1) && (i != this.dgvPedido.RowCount - 1))
                {
                    this.codPedido = Convert.ToInt32(this.dgvPedido.Rows[i].Cells[0].Value);
                    //this.codItem = Convert.ToInt32(this.dgvPedido.Rows[i].Cells[3].Value);
                    this.codFornecedor = Convert.ToInt32(this.dgvPedido.Rows[i].Cells[1].Value);
                    //this.txtQtde.Text = this.dgvPedido.Rows[i].Cells[5].Value.ToString();
                    this.txtValor.Text = this.dgvPedido.Rows[i].Cells[3].Value.ToString();
                    this.dtpPedido.Value = Convert.ToDateTime(this.dgvPedido.Rows[i].Cells[4].Value.ToString());
                    this.txtStatus.Text = this.dgvPedido.Rows[i].Cells[5].Value.ToString();
                    this.txtDescr.Text = this.dgvPedido.Rows[i].Cells[6].Value.ToString();


                    // codpedido, codusuario, coditem, codfornecedor, qtde, valor, data, status, descr
                    // codpedido, codfornecedor, qtde, valor, data, status, descr
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
