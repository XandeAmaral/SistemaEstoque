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
    public partial class FCrudNotaFiscal : Form
    {
        internal Validacoes validacoes;
        public readonly Usuario UsLogado = new Usuario(); //objeto do Usuario Logado
        internal int numNf;

        public FCrudNotaFiscal()
        {
            InitializeComponent();            
        }
        public FCrudNotaFiscal(Usuario usuario)
        {
            InitializeComponent();
            UsLogado = usuario;
        }

        private void txtNF_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtNumNF.Text.Length > 0) { 
                if (validacoes.ApenasNumeros(txtNumNF.Text.ToString()[txtNumNF.Text.Length - 1]))
                {
                    MessageBox.Show("So pode escrever numero.");
                    txtNumNF.Clear();
                    txtNumNF.Focus();
                }
            }

        }

        private void FCrudNotaFiscal_Load(object sender, EventArgs e)
        {
            NotaFiscal Nf;
            try
            {
                Nf = new NotaFiscal();

                this.lblUsuario.Text = UsLogado.nome;
                numNf = Nf.retornarMaiorCod();
                this.txtNumNF.Text = numNf.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
