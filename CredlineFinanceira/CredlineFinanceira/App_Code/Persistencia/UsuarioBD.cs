﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FATEC;
using CredlineFinanceira.App_Code.Classes;
using System.Data;


namespace CredlineFinanceira.App_Code.Persistencia
{
    // teste comentário
    /// <summary>
    /// Summary description for EngenheiroBD
    /// </summary>
    public class UsuarioBD
    {
        //métodos
        public bool Insert(Usuario usuario)
        {
            
           
                System.Data.IDbConnection objConexao;
                System.Data.IDbCommand objCommand;
                string sql = "INSERT INTO usu_usuario (usu_codigo, usu_nome, usu_telefone, usu_celular, usu_endereco, usu_dataContrato, usu_cpf, usu_login, usu_senha, usu_cargo, loj_id) VALUES(?Codigo, ?Nome, ?Telefone, ?Celular, ?Endereco, ?DataContrato, ?Cpf, ?Login, ?Senha, ?Cargo, ?IdLoja)";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?Codigo", usuario.Codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?Nome", usuario.Nome));
                objCommand.Parameters.Add(Mapped.Parameter("?Telefone", usuario.Telefone));
                objCommand.Parameters.Add(Mapped.Parameter("?Celular", usuario.Celular));
                objCommand.Parameters.Add(Mapped.Parameter("?Endereco", usuario.Endereco));
                objCommand.Parameters.Add(Mapped.Parameter("?DataContrato", usuario.DataContrato));
                objCommand.Parameters.Add(Mapped.Parameter("?Cpf", usuario.Cpf));
                objCommand.Parameters.Add(Mapped.Parameter("?Login", usuario.Login));
                objCommand.Parameters.Add(Mapped.Parameter("?Senha", usuario.Senha));
                objCommand.Parameters.Add(Mapped.Parameter("?Cargo", usuario.Cargo));
                objCommand.Parameters.Add(Mapped.Parameter("?IdLoja", usuario.IdLoja));
                objCommand.ExecuteNonQuery();
                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            

            return true;
        }
        //selectall 
        public DataSet SelectAll()
        {
            DataSet ds = new DataSet();
            System.Data.IDbConnection objConexao; System.Data.IDbCommand objCommand; System.Data.IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection(); objCommand = Mapped.Command("SELECT * FROM usu_usuario", objConexao); objDataAdapter = Mapped.Adapter(objCommand); objDataAdapter.Fill(ds);
            objConexao.Close();
            objCommand.Dispose(); objConexao.Dispose();
            return ds;
        }
        //select
        //update
        //delete

        //login

        public Usuario Autentica (string Login, string Senha)
        {
            Usuario obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM usu_usuario WHERE usu_login = ?login and usu_senha = ?senha", objConexao);
           
            objCommand.Parameters.Add(Mapped.Parameter("?login", Login));
            objCommand.Parameters.Add(Mapped.Parameter("?senha", Senha));
            objDataReader = objCommand.ExecuteReader();

            while (objDataReader.Read())
            {
                obj = new Usuario();
                obj.Codigo = Convert.ToInt32(objDataReader["usu_codigo"]);
                obj.Nome = Convert.ToString(objDataReader["usu_nome"]);
                obj.Login = Convert.ToString(objDataReader["usu_login"]);
                obj.Cargo = Convert.ToBoolean(objDataReader["usu_cargo"]);
            }
            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }
        public Usuario Select(int id)
        {
            Usuario obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM usu_usuario WHERE usu_codigo = ?codigo",
           objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", id));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new Usuario();
                obj.Codigo = Convert.ToInt32(objDataReader["usu_codigo"]);
                obj.Nome = Convert.ToString(objDataReader["usu_nome"]);
                obj.Login = Convert.ToString(objDataReader["usu_login"]);
                obj.Cargo = Convert.ToBoolean(objDataReader["usu_cargo"]);
            }
            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();
            return obj;
        }


        public UsuarioBD()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}