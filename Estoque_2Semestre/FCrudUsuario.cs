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
        Validacoes validacoes;

        private void txtNome_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtNome.Text.Length > 0)
            {
                if (validacoes.ApenasLetras(txtNome.Text.ToString()[txtNome.Text.Length - 1]))
                {
                    MessageBox.Show("So pode escrever letras.");
                    txtNome.Clear();
                    txtNome.Focus();
                }
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

        }
    }
}
