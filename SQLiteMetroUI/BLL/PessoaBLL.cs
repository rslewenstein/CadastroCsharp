using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroSimples.DTO;
using CadastroSimples.DAL;
using System.Data;

namespace CadastroSimples.BLL
{
    class PessoaBLL
    {
        Conexao cn = new Conexao();

        public void Incluir(PessoaDTO t)
        {
            try
            {

                cn.conectar();
                string com = "INSERT INTO pessoa(Nome, DtNasc, Cel, Prof) VALUES('"+ t.Nome +"', '" + t.Nascimento.ToShortDateString() + "', '"+ t.Cel +"', '"+ t.Profissao +"')";
                cn.executarCmdSql(com);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar: " + ex.Message);
            }
        }

 //Método para carregar no Grid
        public DataTable carregarDados()
        {
            DataTable dt = new DataTable();
            try
            {

                cn.conectar();

                dt = cn.retDtTable("SELECT Id, Nome, DtNasc, Cel, Prof FROM pessoa");

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar " + ex.Message);
            }

            return dt;
        }
    }
}
