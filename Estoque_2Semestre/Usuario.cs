using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque_2Semestre
{
    internal class Usuario
    {
        public int codigo { get; private set; }
        public string nome { get; private set; }
        public string senha { get; private set; }

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

        public void setnome(string i)
        {
            nome = i;
        }

        public void setsenha(string i)
        {
           
            senha = i;
        }

        public void cadastrar()
        {

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
