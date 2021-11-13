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
        public FHome()
        {
            InitializeComponent();
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
            FConsultaUsuario f = new FConsultaUsuario();
            f.ShowDialog();
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
            FCrudUsuario f = new FCrudUsuario();
            f.ShowDialog();
        }
    }
}
