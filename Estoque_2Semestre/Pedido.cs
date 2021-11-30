using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque_2Semestre
{
    internal class Pedido
    {
        public int codigo { get; private set; }
        public int codUsuario { get; private set; }
        public int codItem { get; private set; }
        public int codFornecedor { get; private set; }
        public int quantidade { get; private set; }
        public double valor { get; private set; }
        public DateTime data { get; private set; }
        public string status { get; private set; }
        public string descr { get; private set; }

        public void setcodigo(int i)
        {
            codigo = i;
        }
        public void setcodigo(string i)
        {
            try
            {
                codigo = Convert.ToInt32(i);
            }
            catch (Exception ex) { throw new Exception("Erro setcodigo:" + ex.Message); }
        }

        public void setcodUsuario(int i)
        {
            codUsuario = i;
        }
        public void setcodUsuario(string i)
        {
            try
            {
                codUsuario = Convert.ToInt32(i);
            }
            catch (Exception ex) { throw new Exception("Erro setcodigo:" + ex.Message); }
        }

        public void setcodItem(int i)
        {
            codItem = i;
        }
        public void setcodItem(string i)
        {
            try
            {
                codItem = Convert.ToInt32(i);
            }
            catch (Exception ex) { throw new Exception("Erro setcodigo:" + ex.Message); }
        }

        public void setcodFornecedor(int i)
        {
            codFornecedor = i;
        }
        public void setcodFornecedor(string i)
        {
            try
            {
                codFornecedor = Convert.ToInt32(i);
            }
            catch (Exception ex) { throw new Exception("Erro setcodigo:" + ex.Message); }
        }

        public void setqtde(int i)
        {

            quantidade = i;
        }
        public void setqtde(string i)
        {
            try
            {
                quantidade = Convert.ToInt32(i);
            }
            catch (Exception ex) { throw new Exception("Erro setcodigo:" + ex.Message); }
        }

        public void setvalor(double i)
        {
            valor = i;
        }
        public void setvalor(string i)
        {
            try
            {
                valor = Convert.ToDouble(i);
            }
            catch (Exception ex) { throw new Exception("Erro setcodigo:" + ex.Message); }
        }

        public void setdata(DateTime i)
        {
            try
            {
                data = i;
            }
            catch (Exception ex) { throw new Exception("Erro setcodigo:" + ex.Message); }
        }
        

        public void setstatus(string i)
        {
            try
            {
                status = i;
            }
            catch (Exception ex) { throw new Exception("Erro setcodigo:" + ex.Message); }
        }

        public void setdescr(string i)
        {
            descr = i;
        }


        public void cadastrar()
        {
            Banco BB;
            try
            {
                BB = new Banco();
                BB.comando.CommandText = "insert into pedido(codusuario, coditem, codfornecedor, qtde, valor, data, status, descr) values(@cu,@ci,@cf,@q,@v,@d,@s,@de); ";
                BB.comando.Parameters.Add("@cu", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.codUsuario;
                BB.comando.Parameters.Add("@ci", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.codItem;
                BB.comando.Parameters.Add("@cf", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.codFornecedor;
                BB.comando.Parameters.Add("@q", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.quantidade;
                BB.comando.Parameters.Add("@v", NpgsqlTypes.NpgsqlDbType.Double).Value = this.valor;
                BB.comando.Parameters.Add("@d", NpgsqlTypes.NpgsqlDbType.Date).Value = this.data;
                BB.comando.Parameters.Add("@s", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.status;
                BB.comando.Parameters.Add("@de", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.descr;
                BB.comando.Prepare();
                BB.comando.ExecuteNonQuery();
                Banco.conexao.Close();
            }
            catch (Exception ex) { throw new Exception("Erro cadastrar:" + ex.Message); }
        }

        public void alterar()
        {
            Banco BB;
            try
            {
                BB = new Banco();
                BB.comando.CommandText = "update pedido set codusuario=@cu, coditem=@ci, codfornecedor=@cf, qtde=@q, valor=@v, data=@d, status=@s, descr=@de where codpedido=@cp";
                BB.comando.Parameters.Add("@cu", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.codUsuario;
                BB.comando.Parameters.Add("@ci", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.codItem;
                BB.comando.Parameters.Add("@cf", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.codFornecedor;
                BB.comando.Parameters.Add("@q", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.quantidade;
                BB.comando.Parameters.Add("@v", NpgsqlTypes.NpgsqlDbType.Double).Value = this.valor;
                BB.comando.Parameters.Add("@d", NpgsqlTypes.NpgsqlDbType.Date).Value = this.data;
                BB.comando.Parameters.Add("@s", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.status;
                BB.comando.Parameters.Add("@de", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.descr;
                BB.comando.Parameters.Add("@cp", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.codigo;
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
                BB.comando.CommandText = "Delete from pedido where codpedido=@cp";
                BB.comando.Parameters.Add("@cp", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.codigo;
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
                BB.comando.CommandText = "Select codpedido, codfornecedor, qtde, valor, data, status, descr from pedido";
                //BB.comando.CommandText = "Select codpedido, codusuario, coditem, codfornecedor, qtde, valor, data, status, descr from pedido";
                BB.comando.Prepare();
                BB.dreader = BB.comando.ExecuteReader();
                BB.tabela = new DataTable();
                BB.tabela.Load(BB.dreader);
                Banco.conexao.Close();
                return (BB.tabela);
            }
            catch (Exception ex) { throw new Exception("Erro listar: " + ex.Message); }
        }

        public DataTable buscaCod(int c)
        {
            Banco BB;
            try
            {
                BB = new Banco();
                if (c != 0)
                {
                    BB.comando.CommandText = "Select codpedido, codusuario, coditem, codfornecedor, qtde, valor, data," +
                        " status, descr from pedido where codpedido='@c'";
                    BB.comando.Parameters.Add("@c", NpgsqlTypes.NpgsqlDbType.Varchar).Value = c;
                    BB.comando.Prepare();
                }
                else
                {
                    BB.comando.CommandText = "Select codpedido, codusuario, coditem, codfornecedor, qtde, valor, data," +
                        " status, descr from pedido";
                }

                BB.dreader = BB.comando.ExecuteReader();
                BB.tabela = new DataTable();
                BB.tabela.Load(BB.dreader);
                Banco.conexao.Close();
                return (BB.tabela);
            }
            catch (Exception ex) { throw new Exception("Erro buscaCod: " + ex.Message); }

        }

        public int retornarMaiorCod()
        {
            int i = 0;
            Banco BB;
            try
            {
                BB = new Banco();
                BB.comando.CommandText = "select codpedido from pedido where codpedido = (select max(codpedido) from pedido)";
                BB.comando.Prepare();
                BB.dreader = BB.comando.ExecuteReader();
                BB.tabela = new DataTable();
                BB.tabela.Load(BB.dreader);
                Banco.conexao.Close();
                if ((BB.tabela.Rows.Count > 0) && (BB.tabela != null))
                {
                    i = Convert.ToInt32(BB.tabela.Rows[0][0]);
                    if (i > 0) return (i);
                    else return (0);
                }
                return (0);
            }
            catch (Exception ex) { throw new Exception("Erro retornarMaiorCod:" + ex.Message); }
        }
    }
}
/*
create table pedido(
codpedido serial primary key,
codusuario int not null,
coditem int,
codfornecedor int not null,
qtde int not null,
valor double not null,
data date default current_date,
status varchar(10),
descr varchar,
constraint rp01 foreign key(codusuario) references usuario(codusuario) on update cascade,
constraint rp03 foreign key(codfornecedor) references fornecedor(codfornecedor) on update cascade
);
 */
