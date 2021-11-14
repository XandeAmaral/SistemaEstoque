﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque_2Semestre
{
    public class Usuario
    {
        public int codigo { get; private set; }
        public string nome { get; private set; }
        public string senha { get; private set; }
        public bool administrador { get; private set; }
        public string email { get; private set; }
        public string login { get; private set; }
        public string usuarioLogado { get; private set; }

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

        public void setSenha(string i)
        {
           
            senha = i;
        }

        public void setAdministrador (bool i)
        {
            if (i) administrador = true;
            else administrador = false;
        }

        public void setEmail(string i)
        {
            email = i;
        }

        public void setLogin(string i)
        {
            login = i;
        }

        public void cadastrar() // grava no banco
        {
            Banco BB;
            try
            {
                BB = new Banco();
                BB.comando.CommandText = "insert into usuario(nome, senha, administrador, login, email) values(@n,@s,@a,@l,@e); ";
                BB.comando.Parameters.Add("@n", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.nome;
                BB.comando.Parameters.Add("@s", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.senha;
                BB.comando.Parameters.Add("@a", NpgsqlTypes.NpgsqlDbType.Boolean).Value = this.administrador;
                BB.comando.Parameters.Add("@l", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.login;
                BB.comando.Parameters.Add("@e", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.email;
                BB.comando.Prepare();
                BB.comando.ExecuteNonQuery();// executa o sql passado no banco
                Banco.conexao.Close();
            }
            // dispara uma exceção.
            catch (Exception ex) { throw new Exception("Erro gravar:" + ex.Message); }

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
        public Usuario fazerLogin(string l, string s) // faz o login e retorna o nome  e codigo
        {
            Banco BB;
            Usuario Us;
            try
            {
                BB = new Banco();
                Us = new Usuario();
                
                BB.comando.CommandText = "Select codusuario,nome,administrador,email,login from usuario where login = @l and senha = @s";
                BB.comando.Parameters.Add("@l", NpgsqlTypes.NpgsqlDbType.Varchar).Value = l;
                BB.comando.Parameters.Add("@s", NpgsqlTypes.NpgsqlDbType.Varchar).Value = s;
                BB.comando.Prepare();
                BB.dreader = BB.comando.ExecuteReader();
                if ((BB.dreader != null) && (BB.dreader.Read()))
                {
                    Us.setCodigo(Convert.ToInt32(BB.dreader[0]));
                    Us.setNome(BB.dreader[1].ToString());
                    Us.setAdministrador(Convert.ToBoolean(BB.dreader[2]));
                    Us.setEmail(BB.dreader[3].ToString());
                    Us.setLogin(BB.dreader[4].ToString());
                    BB.dreader.Close();
                    Banco.conexao.Close();
                    return (Us);
                }
                else
                {
                    BB.dreader.Close();
                    Banco.conexao.Close();
                    return (Us);
                }
            }
            catch (Exception ex) { throw new Exception("Erro fazerLogin: " + ex.Message); }
        }
    }
}
/*

create table usuario(
codusuario serial primary key,
nome varchar(50) not null,
senha varchar(20) not null,
administrador bool default false,
login varchar(30) not null,
email varchar(50) not null
);

 */
