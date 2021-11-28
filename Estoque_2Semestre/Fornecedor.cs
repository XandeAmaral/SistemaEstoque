using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque_2Semestre
{
    internal class Fornecedor
    {
        public int codigo { get; private set; }
        public string nome { get; private set; }
        public string cnpj { get; private set; }
        public string email { get; private set; }
        public string telefone { get; private set; }

        public void setCodigo(int i)
        {
            codigo = i;
        }
        public void setCodigo(string i)
        {
            try
            {
                codigo = Convert.ToInt32(i);
            }
            catch (Exception ex) { throw new Exception("Erro setCodigo:" + ex.Message); }
        }
        public void setNome(string i)
        {
            nome = i;
        }
        public void setEmail(string i)
        {
            email = i;
        }
        public void setCnpj(string i)
        {
            cnpj = i;
        }
        public void setTelefone(string i)
        {
            telefone = i;
        }

        public void cadastrar()
        {
            Banco BB;
            try
            {
                BB = new Banco();
                BB.comando.CommandText = "insert into fornecedor(nome, cnpj, email, telefone) values(@n,@c,@e,@t); ";
                BB.comando.Parameters.Add("@n", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.nome;
                BB.comando.Parameters.Add("@c", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.cnpj;
                BB.comando.Parameters.Add("@e", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.email;
                BB.comando.Parameters.Add("@t", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.telefone;
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
                BB.comando.CommandText = "Update fornecedor set nome=@n,cnpj=@cn,email=@e,telefone=@t where codfornecedor=@c";
                BB.comando.Parameters.Add("@n", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.nome;
                BB.comando.Parameters.Add("@cn", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.cnpj;
                BB.comando.Parameters.Add("@e", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.email;
                BB.comando.Parameters.Add("@t", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.telefone;
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
                BB.comando.CommandText = "Delete from fornecedor where codfornecedor=@c";
                BB.comando.Parameters.Add("@c", NpgsqlTypes.NpgsqlDbType.Integer).Value = this.codigo;
                BB.comando.Prepare();
                BB.comando.ExecuteNonQuery();
                Banco.conexao.Close();
            }
            catch (Exception ex) { throw new Exception("Erro remover:" + ex.Message); }

        }

        public DataTable buscaNome(string n)
        {
            Banco BB;
            try
            {
                BB = new Banco();
                if (n.Length > 0)
                {
                    BB.comando.CommandText = "Select nome, cnpj, email, telefone from fornecedor where nome ilike '@n'";
                    BB.comando.Parameters.Add("@n", NpgsqlTypes.NpgsqlDbType.Varchar).Value = "%" + n + "%";
                    BB.comando.Prepare();
                }
                else
                {
                    BB.comando.CommandText = "Select nome, cnpj, email, telefone from fornecedor order by nome";
                }

                BB.dreader = BB.comando.ExecuteReader();
                BB.tabela = new DataTable();
                BB.tabela.Load(BB.dreader);
                Banco.conexao.Close();
                return (BB.tabela);
            }
            catch (Exception ex) { throw new Exception("Erro Busca: " + ex.Message); }

        }

        public DataTable listar() // lista todos os fornecedores
        {
            Banco BB;
            try
            {
                BB = new Banco();
                BB.comando.CommandText = "Select codfornecedor, nome, cnpj, email, telefone from fornecedor";
                BB.comando.Prepare();
                BB.dreader = BB.comando.ExecuteReader();
                BB.tabela = new DataTable();
                BB.tabela.Load(BB.dreader);
                Banco.conexao.Close();
                return (BB.tabela);
            }
            catch (Exception ex) { throw new Exception("Erro listar: " + ex.Message); }
        }

        public DataTable listarPorCod()
        {
            Banco BB;
            try
            {
                BB = new Banco();
                BB.comando.CommandText = "Select codfornecedor, nome from fornecedor order by codfornecedor";
                BB.comando.Prepare();
                BB.dreader = BB.comando.ExecuteReader();
                BB.tabela = new DataTable();
                BB.tabela.Load(BB.dreader);
                Banco.conexao.Close();
                return (BB.tabela);
            }
            catch (Exception ex) { throw new Exception("Erro listarPorCod: " + ex.Message); }
        }
    }

}
/*

create table fornecedor(
codfornecedor serial primary key,
nome varchar(50) not null,
cnpj varchar(16) not null,
telefone varchar(17) not null,
email varchar(50) not null
);

 */