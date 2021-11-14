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
    public partial class FHome : Form
    {
        public readonly Usuario UsLogado; //objeto do Usuario Logado

        public FHome()
        {
            InitializeComponent();
        }
        public FHome(Usuario usuario)
        {
            InitializeComponent();
            UsLogado = usuario;
        }
        private void FHome_Load(object sender, EventArgs e) // coloca o nome do UsLogado
        {
            lblUsuario.Text = UsLogado.nome;
        }

        private void pedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FConsultaPedido f = new FConsultaPedido();
            f.ShowDialog();
        }

        private void notaFiscalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FConsultaNotaFiscal f = new FConsultaNotaFiscal();
            f.ShowDialog();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.UsLogado.administrador)
            {
                FConsultaUsuario f = new FConsultaUsuario();
                f.ShowDialog();
            }
            else MessageBox.Show("Permitido so para administradores.");
        }

        private void pedidoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FCrudPedido f = new FCrudPedido();
            f.ShowDialog();
        }

        private void notaFiscalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FCrudNotaFiscal f = new FCrudNotaFiscal();
            f.ShowDialog();
        }

        private void usuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.UsLogado.administrador)
            {
                FCrudUsuario f = new FCrudUsuario(UsLogado); //passa o UsLogado
                f.ShowDialog();
            }
            else MessageBox.Show("Permitido so para administradores.");
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.UsLogado.administrador)
            {
                FCrudFornecedor f = new FCrudFornecedor(UsLogado); //passa o UsLogado
                f.ShowDialog();
            }
            else MessageBox.Show("Permitido so para administradores.");
        }
    }
}
