using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace CadastroSimples.DAL
{
    class Conexao
    {
         //Variáveis globais

        //variavel de conexão com o BD
        SQLiteConnection sqlcon;

        private DataTable data;
        private SQLiteDataAdapter da;
        private SQLiteDataReader dr;
        private SQLiteCommandBuilder cb;

        public void conectar()
        {
          
            //nome do banco
            string banco = "dbCadSimples.db";

            //verifica se o banco existe
            if (!File.Exists(banco))
            {
                MessageBox.Show ("Banco de Dados " + banco + " não existe");
                Application.Exit();
            }

            //criando uma conexao com banco de dados
            sqlcon = new SQLiteConnection("Data Source=" + banco);
            sqlcon.Open();

            //verifica se conectou e abriu o banco
            if (sqlcon.State != ConnectionState.Open)
            {
                MessageBox.Show("Banco de Dados " + banco + " não aberto");
                Application.Exit();
            }

        }
        
        //Método para executar comandos no BD
        public void executarCmdSql(string comdSQL)
        {
            try
            {

                SQLiteCommand comd = new SQLiteCommand(comdSQL, sqlcon);
              //  comd.Connection.Open();
                comd.ExecuteNonQuery();
   
                
                
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro! " + ex);
            }
        }

        //Método para retornar um Data Table (retorna uma tabela de dados. 
        //Pode preencher um grid ou um combo com esse método.
        public DataTable retDtTable(string sql)
        {
            data = new DataTable();
            da = new SQLiteDataAdapter(sql, sqlcon);
            cb = new SQLiteCommandBuilder(da);
            da.Fill(data);

            return data;
        }


        //Método para solicitar dados somente como leitura.
        public SQLiteDataReader retDtReader(string sql)
        {
            SQLiteCommand comm = new SQLiteCommand(sql, sqlcon);
            SQLiteDataReader dr = comm.ExecuteReader();
            dr.Read();
            return dr;
        }
    }

    }

