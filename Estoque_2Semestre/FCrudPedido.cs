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
        private Validacoes validacoes;
        private void txtNPedido_TextChanged(object sender, EventArgs e)
        {
            if (txtNPedido.Text.Length > 0)
            {
                if (validacoes.ApenasNumeros(txtNPedido.Text.ToString()[txtNPedido.Text.Length - 1]))
                {
                    MessageBox.Show("So pode escrever numero.");
                    txtNPedido.Clear();
                    txtNPedido.Focus();
                }
            }
        }
        private void txtCNPJ_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtCNPJ.Text.Length > 0)
            {
                if (validacoes.ApenasNumeros(txtCNPJ.Text.ToString()[txtCNPJ.Text.Length - 1]))
                {
                    MessageBox.Show("So pode escrever numero.");
                    txtNPedido.Clear();
                    txtNPedido.Focus();
                }
            }
        }
        private void txtTelefone_KeyUp(object sender, KeyEventArgs e)
        {
            if (validacoes.VerificaVazio(txtTelefone.Text))
            {
                MessageBox.Show("VerificaVazio OK.");
                if (validacoes.ApenasNumeros(txtTelefone.Text.ToString()[txtTelefone.Text.Length - 1]))
                {
                    MessageBox.Show("So pode escrever numero.");
                    txtNPedido.Clear();
                    txtNPedido.Focus();
                }
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Pedido pe;
            try
            {
                pe = new Pedido();
              //  pe.setcodItens(this.txtNome.Text.Trim()); // função da classe Pedido
              //  pe.setcodNotaFiscal(this.txtTelefone.Text.Trim());

              //  pe.gravar(); // função da classe Pedido

                this.txtCNPJ.Clear(); // limpa o textbox
                this.txtFornecedor.Clear();
                this.txtTelefone.Clear();
                this.txtEmail.Clear();
                this.txtNPedido.Clear();
                this.txtNPedido.Focus(); // volta o foco pro textbox

                MessageBox.Show("Cadastrado com sucesso"); // mostra uma mensagem na tela
              //  mostrar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
