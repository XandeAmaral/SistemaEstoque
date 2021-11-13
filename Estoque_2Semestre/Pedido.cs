using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque_2Semestre
{
    internal class Pedido
    {
        public int codigo { get; private set; }
        public int codUsuario { get; private set; }
        public int codNotaFiscal { get; private set; }
        public int codItens { get; private set; }
        public int codFornecedor { get; private set; }
        public int quantidade { get; private set; }
        public double valor { get; private set; }
        public string data { get; private set; }
        public string status { get; private set; }

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

        public void setcodNotaFiscal(int i)
        {
            codNotaFiscal = i;
        }
        public void setcodNotaFiscal(string i)
        {
            try
            {
                codNotaFiscal = Convert.ToInt32(i);
            }
            catch (Exception ex) { throw new Exception("Erro setcodigo:" + ex.Message); }
        }

        public void setcodItens(int i)
        {
            codItens = i;
        }
        public void setcodItens(string i)
        {
            try
            {
                codItens = Convert.ToInt32(i);
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

        public void setdata(int i)
        {
            data = i.ToString();
        }
        public void setdata(string i)
        {
            try
            {
                data = i;
            }
            catch (Exception ex) { throw new Exception("Erro setcodigo:" + ex.Message); }
        }

        public void setstatus(int i)
        {
            status = i.ToString();
        }
        public void setstatus(string i)
        {
            try
            {
                status = i;
            }
            catch (Exception ex) { throw new Exception("Erro setcodigo:" + ex.Message); }
        }



        public void cadastrar() // função pra inserir os valores no banco
        {
            /*
            Banco BB;
            try
            {
                BB = new Banco();
                BB.comando.CommandText = "insert into cliente(nome,fone) values(@n,@f);";
                BB.comando.Parameters.Add("@n", NpgsqlTypes.NpgsqlDbType.Varchar).Value = nome;
                BB.comando.Parameters.Add("@f", NpgsqlTypes.NpgsqlDbType.Varchar).Value = fone;
                BB.comando.Prepare();
                BB.comando.ExecuteNonQuery();// executa o sql passado no banco
                Banco.conexao.Close();
            }
            // dispara uma exceção.
            catch (Exception ex) { throw new Exception("Erro gravar:" + ex.Message); }
            */
        }

        public void buscar(int cod)
        {

        }

        public void alterar(int cod)
        {

        }

        public void remover(int cod)
        {

        }
    }
}
