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
        public FCrudNotaFiscal()
        {
            InitializeComponent();            
        }

        private void txtNF_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtNF.Text.Length > 0) { 
                if (validacoes.ApenasNumeros(txtNF.Text.ToString()[txtNF.Text.Length - 1]))
                {
                    MessageBox.Show("So pode escrever numero.");
                    txtNF.Clear();
                    txtNF.Focus();
                }
            }

        }
    }
}
