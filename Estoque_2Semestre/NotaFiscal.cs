using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque_2Semestre
{
    internal class NotaFiscal
    {
        public int codigo { get; set; }
        public int codpedido { get; set; }
        public int numnf { get; set; }
        public DateTime dateemissao { get; set; }
        public string natoperacao { get; set; }
        public string xmlimportado { get; set; }

        public void setcodigo(int i)
        {
            codigo = i;
        }
        public void setcodigo(string i)
        {
            codigo = Convert.ToInt32(i);
        }

        public void setcodpedido (int i)
        {
            codpedido = i;
        }
        public void setcodpedido (string i)
        {
            codpedido = Convert.ToInt32(i);
        }

        public void setnumnf(int i)
        {
            numnf = i;
        }
        public void setnumnf(string i)
        {
            numnf = Convert.ToInt32(i);
        }

        public void setdataemissao(string i)
        {
            dateemissao = Convert.ToDateTime(i);
        }
        
        public void setnatoperacao(string i)
        {
            natoperacao = i;
        }

        public void setxmlimportado(string i)
        {
            xmlimportado = i;
        }


        public void cadastrar()
        {
            Banco BB;
            try
            {
                BB = new Banco();
                BB.comando.CommandText = "insert into notafiscal(codpedido, numnf, dataemissao, natoperacao, xmlimportado)" +
                    " values(@cp,@n,@d,@na,@x) ";
                BB.comando.Parameters.Add("@cp", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.codpedido;
                BB.comando.Parameters.Add("@n", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.numnf;
                BB.comando.Parameters.Add("@d", NpgsqlTypes.NpgsqlDbType.Date).Value = this.dateemissao;
                BB.comando.Parameters.Add("@na", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.natoperacao;
                BB.comando.Parameters.Add("@x", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.xmlimportado;
                BB.comando.Prepare();
                BB.comando.ExecuteNonQuery();
                Banco.conexao.Close();
            }
            catch (Exception ex) { throw new Exception("Erro cadastrar:" + ex.Message); }

        }

        public DataTable buscaNF(int n) 
        {
            Banco BB;
            try
            {
                BB = new Banco();
                if (n > 0)
                {
                    BB.comando.CommandText = "Select codpedido, numnf, dataemissao, natoperacao, xmlimportado" +
                        " from notafiscal where numnf='@n'";
                    BB.comando.Parameters.Add("@n", NpgsqlTypes.NpgsqlDbType.Integer).Value = n;
                    BB.comando.Prepare();
                }
                else
                {
                    BB.comando.CommandText = "Select codpedido, numnf, dataemissao, natoperacao, xmlimportado from notafiscal";
                }

                BB.dreader = BB.comando.ExecuteReader();
                BB.tabela = new DataTable();
                BB.tabela.Load(BB.dreader);
                Banco.conexao.Close();
                return (BB.tabela);
            }
            catch (Exception ex) { throw new Exception("Erro Busca: " + ex.Message); }

        }

        public void alterar()
        {
            Banco BB;
            try
            {
                BB = new Banco();
                BB.comando.CommandText = "update notafiscal set codpedido=@cp, numnf=@n, dataemissao=@d,natoperacao=@na" +
                    "xmlimportado=@x where codnf=@c";
                BB.comando.Parameters.Add("@cp", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.codpedido;
                BB.comando.Parameters.Add("@n", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.numnf;
                BB.comando.Parameters.Add("@d", NpgsqlTypes.NpgsqlDbType.Date).Value = this.dateemissao;
                BB.comando.Parameters.Add("@na", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.natoperacao;
                BB.comando.Parameters.Add("@x", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.xmlimportado;
                BB.comando.Parameters.Add("@c", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.codigo;
                BB.comando.Prepare();
                BB.comando.ExecuteNonQuery();
                Banco.conexao.Close();
            }
            catch (Exception ex) { throw new Exception("Erro alterar:" + ex.Message); }

        }

        public void remover()
        {
            Banco BB;
            try
            {
                BB = new Banco();
                BB.comando.CommandText = "Delete from notafiscal where codnf=@c";
                BB.comando.Parameters.Add("@c", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.codigo;
                BB.comando.Prepare();
                BB.comando.ExecuteNonQuery();
                Banco.conexao.Close();
            }
            catch (Exception ex) { throw new Exception("Erro remover:" + ex.Message); }
        }

        public DataTable listar()
        {
            Banco BB;
            try
            {
                BB = new Banco();
                BB.comando.CommandText = "Select codpedido, numnf, dataemissao, natoperacao, xmlimportado from notafiscal";
                BB.comando.Prepare();
                BB.dreader = BB.comando.ExecuteReader();
                BB.tabela = new DataTable();
                BB.tabela.Load(BB.dreader);
                Banco.conexao.Close();
                return (BB.tabela);
            }
            catch (Exception ex) { throw new Exception("Erro listar: " + ex.Message); }
        }

        public int retornarMaiorCod()
        {
            int i = 0;
            Banco BB;
            try
            {
                BB = new Banco();
                BB.comando.CommandText = "select codnf from notafiscal where codnf = (select max(codnf) from notafiscal)";
                BB.comando.Prepare();
                BB.comando.ExecuteNonQuery();
                Banco.conexao.Close();
                i = Convert.ToInt32(BB.tabela.Rows[0][0]);
                if (i > 0) return (i);
                else return (0);
            }
            catch (Exception ex) { throw new Exception("Erro retornarMaiorCod:" + ex.Message); }
        }
    }
}

/*
create table notafiscal(
codnf serial primary key,
codpedido int not nul,
numnf int,
dataemissao date,
natoperacao varchar(15),
xmlimportado varchar(),
constraint rnf01 foreign key(codpedido) references pedido(codpedido) on update cascade,
);
 */