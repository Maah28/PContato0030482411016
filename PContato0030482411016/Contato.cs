using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PContato0030482411016
{
    internal class Contato
    {
        public int Idcontato { get; set; }
        public string Nomecontato { get; set; }
        public string Endcontato { get; set; }
        public int Cidadeidcidade { get; set; }
        public string Celcontato { get; set; }
        public string Emailcontato { get; set; }
        public DateTime Dtcadastrocontato { get; set; }

        public DataTable Listar()
        {
            SqlDataAdapter daContato;

            DataTable dtContato = new DataTable();

            try
            {
                daContato = new SqlDataAdapter("SELECT * FROM CONTATO ORDER BY NOME_CONTATO", frmPrincipal.conexao);
                daContato.Fill(dtContato); //Dados
                daContato.FillSchema(dtContato, SchemaType.Source); //Informações da estrutura da tabala
            }
            catch (Exception)
            {
                throw; // Criar uma exceção
            }
            return dtContato;
        }

        public int Incluir() // INCLUSAO
        {
            int retorno = 0;

            try
            {
                SqlCommand mycommand;

                mycommand = new SqlCommand("INSERT INTO CONTATO VALUES (@nomecontato,@endcontato,@cidadeidcidade," +
                    "@celcontato,@emailcontato,@dtcadastrocontato)", frmPrincipal.conexao);

                mycommand.Parameters.Add(new SqlParameter("@nomecontato", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@endcontato", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@cidadeidcidade", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@celcontato", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@emailcontato", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@dtcadastrocontato", SqlDbType.Date));


                mycommand.Parameters["@nomecontato"].Value = Nomecontato;
                mycommand.Parameters["@endcontato"].Value = Endcontato;
                mycommand.Parameters["@cidadeidcidade"].Value = Cidadeidcidade;
                mycommand.Parameters["@celcontato"].Value = Celcontato;
                mycommand.Parameters["@emailcontato"].Value = Emailcontato;
                mycommand.Parameters["@dtcadastrocontato"].Value = Dtcadastrocontato;

                retorno = mycommand.ExecuteNonQuery();


            }
            catch (Exception)
            {
                throw;
            }

            return retorno;
        }

        public int Alterar() // alteração
        {
            int retorno = 0;

            try
            {
                SqlCommand mycommand;

                mycommand = new SqlCommand("UPDATE CONTATO SET NOME_CONTATO=@nomecontato,END_CONTATO=@endcontato," +
                    " CIDADE_ID_CIDADE=@cidadeidcidade, CEL_CONTATO=@celcontato, EMAIL_CONTATO=@emailcontato, " +
                    " DTCADASTRO_CONTATO=@dtcadastrocontato WHERE ID_CONTATO = @idcontato", frmPrincipal.conexao);

                mycommand.Parameters.Add(new SqlParameter("@idcontato", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@nomecontato", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@endcontato", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@cidadeidcidade", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@celcontato", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@emailcontato", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@dtcadastrocontato", SqlDbType.Date));


                mycommand.Parameters["@idcontato"].Value = Idcontato;
                mycommand.Parameters["@nomecontato"].Value = Nomecontato;
                mycommand.Parameters["@endcontato"].Value = Endcontato;
                mycommand.Parameters["@cidadeidcidade"].Value = Cidadeidcidade;
                mycommand.Parameters["@celcontato"].Value = Celcontato;
                mycommand.Parameters["@emailcontato"].Value = Emailcontato;
                mycommand.Parameters["@dtcadastrocontato"].Value = Dtcadastrocontato;


                retorno = mycommand.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

        public int Excluir() // EXCLUSÃO 
        {
            int nReg = 0;

            try
            {
                SqlCommand mycommand;

                mycommand = new SqlCommand("DELETE FROM CONTATO WHERE ID_CONTATO=@idcontato", frmPrincipal.conexao);

                mycommand.Parameters.Add(new SqlParameter("@idcontato", SqlDbType.Int));
                mycommand.Parameters["@idcontato"].Value = Idcontato;

                nReg = mycommand.ExecuteNonQuery();
            }

            catch (Exception)
            {
                throw;
            }
            return nReg;
        }




    }
}