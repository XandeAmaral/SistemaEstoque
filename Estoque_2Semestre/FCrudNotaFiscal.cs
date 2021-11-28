using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Estoque_2Semestre
{
    public partial class FCrudNotaFiscal : Form
    {
        internal Validacoes Va;
        public readonly Usuario UsLogado = new Usuario(); //objeto do Usuario Logado
        internal int numNf;
        internal string[] xml;
        internal int codPedido;

        public FCrudNotaFiscal()
        {
            InitializeComponent();            
        }
        public FCrudNotaFiscal(Usuario usuario)
        {
            InitializeComponent();
            UsLogado = usuario;
        }        
        private void FCrudNotaFiscal_Load(object sender, EventArgs e)
        {
            NotaFiscal Nf;
            try
            {
                Nf = new NotaFiscal();

                this.lblUsuario.Text = UsLogado.nome;
                //numNf = Nf.retornarMaiorCod();
                //this.txtNumNF.Text = numNf.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private int testarElementos()
        {
            int aux = 0;

            try
            {
                Va = new Validacoes();

                aux += Va.NaoVazio(this.txtNumNF.Text);
                aux += Va.NaoVazio(this.txtOperacao.Text);
                aux += Va.NaoVazio(this.txtValor.Text);

                return aux;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return aux; }

        }
        private void limpar()
        {
            this.txtNumNF.Clear();
            this.txtOperacao.Clear();
            this.txtValor.Clear();
            this.lstNF.Clear();
        }
        private void lerXmlNfe()
        {
            var arquivo = @"D:\nfe.xml";
            var item = "";
            var cProd = "";
            var xProd = "";
            var qCom = "";
            var vUnCom = "";
            var vProd = "";

            using (XmlReader meuXml = XmlReader.Create(arquivo))
            {
                var fimItens = false;

                while (meuXml.Read())
                {
                    //Cabecalho;
                    if (meuXml.NodeType == XmlNodeType.Element && meuXml.Name == "natOp")
                        this.txtOperacao.Text = meuXml.ReadElementContentAsString();
                    if (meuXml.NodeType == XmlNodeType.Element && meuXml.Name == "nNF")
                        this.txtNumNF.Text = meuXml.ReadElementContentAsString();
                    if (meuXml.NodeType == XmlNodeType.Element && meuXml.Name == "dhEmi")
                        this.dtpNF.Text = meuXml.ReadElementContentAsString();

                    //itens da nf
                    if (meuXml.NodeType == XmlNodeType.Element && meuXml.Name == "det")
                    {
                        //lendo atributo da tag <det>
                        item = meuXml.GetAttribute("nItem");

                        //variaveis pra guardar conteudo do item
                        cProd = "";
                        xProd = "";
                        qCom = "";
                        vUnCom = "";
                        vProd = "";
                    }
                    else if (meuXml.NodeType == XmlNodeType.Element && meuXml.Name == "total")
                    {
                        fimItens = true;
                    }

                    if (!fimItens)
                    {
                        if (meuXml.NodeType == XmlNodeType.Element && meuXml.Name == "cProd")
                            cProd = meuXml.ReadElementContentAsString();

                        if (meuXml.NodeType == XmlNodeType.Element && meuXml.Name == "xProd")
                            xProd = meuXml.ReadElementContentAsString();

                        if (meuXml.NodeType == XmlNodeType.Element && meuXml.Name == "qCom")
                            qCom = meuXml.ReadElementContentAsString();

                        if (meuXml.NodeType == XmlNodeType.Element && meuXml.Name == "vUnCom")
                            vUnCom = meuXml.ReadElementContentAsString();

                        if (meuXml.NodeType == XmlNodeType.Element && meuXml.Name == "vProd")
                        {
                            vProd = meuXml.ReadElementContentAsString().Replace(".", ",");
                            this.lstNF.Items.Add(new ListViewItem(new[] { item, cProd, xProd, qCom, vUnCom.ToString
                            (), vProd.ToString().Replace(".", ",") }));
                        }
                    }
                    //rodape
                    if (meuXml.NodeType == XmlNodeType.Element && meuXml.Name == "vNF")
                        this.txtValor.Text = meuXml.ReadElementContentAsString().Replace(".", ",");
                }
            }
        }     
        private void btnImportarXML_Click(object sender, EventArgs e)
        {
            lerXmlNfe();
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            NotaFiscal Nf;

            try
            {
                Nf = new NotaFiscal();

                if(testarElementos() == 0)
                {
                    //Nf.setcodpedido(this.codPedido);
                    Nf.setdataemissao(this.dtpNF.Text);
                    Nf.setnatoperacao(this.txtOperacao.Text);
                    Nf.setnumnf(this.txtNumNF.Text);
                    Nf.setxmlimportado(this.xml);
                    Nf.setvalor(this.txtValor.Text);

                    Nf.cadastrar();

                    this.limpar();

                    MessageBox.Show("Cadastrado com Sucesso");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}
