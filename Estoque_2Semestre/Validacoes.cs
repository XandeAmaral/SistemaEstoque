using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * essa classe serve para encapsular as validações dos formularios,
 * agrupando tudo em uma classe
*/

namespace Estoque_2Semestre
{
    internal class Validacoes
    {
        public bool ApenasLetras(char caracter)
        {
            try
            {

                if (caracter >= '0' && caracter <= '9')
                { // se estiver dentro de 0 - 9
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex) { throw new Exception("Erro ApenasLetras:" + ex.Message); }
        }
        public bool ApenasLetras(string palavra)
        {
            try
            {
                foreach (char letra in palavra)
                {
                    if (letra >= '0' && letra <= '9')
                    { // se estiver dentro de 0 - 9
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                return true;
            }
            catch (Exception ex) { throw new Exception("Erro ApenasLetras:" + ex.Message); }
        }
        public bool ApenasNumeros(char caracter)
        {
            try
            {
                if (caracter >= '0' && caracter <= '9')
                { // se estiver dentro de 0 - 9
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex) { throw new Exception("Erro ApenasNumeros:" + ex.Message); }
        }
        public bool ApenasNumeros(string palavra)
        {
            try
            {
                foreach (char letra in palavra)
                {
                    if (letra >= '0' && letra <= '9')
                    { // se estiver dentro de 0 - 9
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ApenasNumeros:" + ex.Message);
            }
}
        public int NaoVazio (string palavra)
        {
            if (string.IsNullOrEmpty(palavra)) return 1;
            else return 0;
        }
    }
}
