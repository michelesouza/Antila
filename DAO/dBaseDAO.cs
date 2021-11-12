using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class dBaseDAO
    {
        #region Atributos
        protected string strConn = string.Empty;
        protected SqlConnection cn = null;
        protected SqlCommand cmd = null;
        #endregion

        #region Construtor
        /// <summary>
        /// Contrutor padrão sem argumentos, seta a variável com o caminho do banco
        /// </summary>
        public dBaseDAO()
        {
            try
            {
                strConn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Abre a conexão com o banco de dados
        /// </summary>
        protected void OpenConnection()
        {
            cn = new SqlConnection(strConn);
            cn.Open();
            cmd.Connection = cn;
        }

        /// <summary>
        /// Fecha a conexão com o banco de dados
        /// </summary>
        protected void CloseConnection()
        {
            if (cn != null)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
            if (cmd != null) cmd.Dispose();
        }


        /// <summary>
        /// Executa comando no banco de dados.
        /// </summary>
        /// <param name="commandText">Procedure a ser executada</param>
        /// <param name="cmd">Conexão com o banco de dados</param>
        /// <returns>Retorna as informações selecionadas</returns>
        protected IDataReader ExecReader(string cmdText, SqlCommand cmd)
        {
            return this.ExecReader(cmdText, cmd, null);
        }

        /// <summary>
        /// Executa comando no banco de dados.
        /// </summary>
        /// <param name="commandText">Procedure a ser executada</param>
        /// <param name="parameters">Parametros da procedures</param>
        /// <param name="cmd">Conexão com o banco de dados</param>
        /// <returns>Retorna as informações selecionadas</returns>
        protected IDataReader ExecReader(string cmdText, SqlCommand cmd, SqlParameter[] parameters)
        {
            try
            {
                cmd.Parameters.Clear();

                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = cmdText;

                OpenConnection();

                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Executa comando no Banco de dados e retorna quantidade de linhas alteradas.
        /// </summary>
        /// <param name="commandText">Procedure a ser executada</param>
        /// <param name="cmd">Conexão com o banco de dados</param>
        /// <returns>Retorna as quantidades de linhas afetadas</returns>
        protected int ExecNonQuery(string cmdText, SqlCommand cmd)
        {
            return ExecNonQuery(cmdText, cmd, null);
        }

        /// <summary>
        /// Executa comando no Banco de dados e retorna as quantidades de linhas alteradas.
        /// </summary>
        /// <param name="commandText">Procedure a ser executada</param>
        /// <param name="parameters">Parametros da procedures</param>
        /// <param name="cmd">Conexão com o banco de dados</param>
        /// <returns>Retorna as quantidades de linhas afetadas</returns>
        protected int ExecNonQuery(string cmdText, SqlCommand cmd, SqlParameter[] parameters)
        {
            try
            {
                cmd.Parameters.Clear();

                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = cmdText;
                OpenConnection();

                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected int ExecScalar(string cmdText, SqlCommand cmd, SqlParameter[] parameters)
        {

            try
            {
                cmd.Parameters.Clear();

                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = cmdText;

                OpenConnection();


                int i = int.Parse(cmd.ExecuteScalar().ToString());

                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Valida se a coluna existe no resultado da consulta SQL, evitando o erro quando adicionado nova coluna
        /// Adicionado por: Joabe e Nicolas em 11/04/2016
        /// </summary>
        public bool ColunaExiste(string nome, IDataReader dr)
        {
            var columns = Enumerable.Range(0, dr.FieldCount).Select(dr.GetName).ToList();

            return (columns.Count(c => c.ToLower().Equals(nome.ToLower())) > 0);
        }



        protected int? GetInt32Nullable(string nome, IDataReader dr)
        {
            int? valor = null;

            if (ColunaExiste(nome, dr))
            {

                if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                    valor = dr.GetInt32(dr.GetOrdinal(nome));
            }

            return valor;
        }


        protected int GetInt32(string nome, IDataReader dr)
        {
            int valor = 0;

            if (ColunaExiste(nome, dr))
            {

                if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                    valor = dr.GetInt32(dr.GetOrdinal(nome));
            }

            return valor;
        }


        protected string GetString(string nome, IDataReader dr)
        {
            string valor = null;

            if (ColunaExiste(nome, dr))
            {
                if (dr[nome] != DBNull.Value)
                {
                    if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                        valor = dr.GetString(dr.GetOrdinal(nome)).Trim();
                }
            }

            return valor;
        }

        protected DateTime GetDateTime(string nome, IDataReader dr)
        {
            DateTime valor = new DateTime();

            if (ColunaExiste(nome, dr))
            {

                if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                    valor = dr.GetDateTime(dr.GetOrdinal(nome));
            }

            return valor;
        }

        protected DateTime? GetDateTimeNullable(string nome, IDataReader dr)
        {
            DateTime? valor = null;

            if (ColunaExiste(nome, dr))
            {

                if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                    valor = dr.GetDateTime(dr.GetOrdinal(nome));
            }

            return valor;
        }

        protected decimal GetDecimal(string nome, IDataReader dr)
        {
            decimal valor = 0;

            if (ColunaExiste(nome, dr))
            {

                if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                    valor = dr.GetDecimal(dr.GetOrdinal(nome));
            }

            return valor;
        }

        protected decimal? GetDecimalNullable(string nome, IDataReader dr)
        {
            decimal? valor = null;

            if (ColunaExiste(nome, dr))
            {

                if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                    valor = dr.GetDecimal(dr.GetOrdinal(nome));
            }

            return valor;
        }

        /// <summary>
        /// Monta os parâmetros para execução da Stored Procedure.
        /// </summary>
        /// <param name="item">Indice do parâmetro</param>
        /// <param name="parametros">array de parâmetro a ser montado</param>
        /// <param name="direction">Direção do parametro(input/output)</param>
        /// <param name="nome">Nome do parametro(@id)</param>
        /// <param name="valor">Valor do parametro</param>
        /// <param name="dbType">Tipo de dado do parametro</param>
        protected void MontarParametro
            (int item, SqlParameter[] parametros, ParameterDirection direction,
                string nome, object valor, SqlDbType dbType)
        {
            parametros[item] = new SqlParameter();
            parametros[item].Direction = direction;
            parametros[item].ParameterName = nome;
            parametros[item].SqlDbType = dbType;
            if (valor == null)
                valor = DBNull.Value;
            parametros[item].SqlValue = valor;
        }

        /// <summary>
        /// Converte um DataReader para um DataSet
        /// </summary>
        /// <param name="reader">DataReader que será convertido</param>
        /// <returns>DataSet preenchido com o conteúdo do DataReader</returns>
        public static DataSet ConverterDataReaderParaDataSet(IDataReader reader)
        {
            DataSet dataSet = new DataSet();

            do
            {
                ///Cria um novo data table
                DataTable schemaTable = reader.GetSchemaTable();
                DataTable dataTable = new DataTable();

                if (schemaTable != null)
                {
                    ///Varre os registos encontrados
                    for (int i = 0; i < schemaTable.Rows.Count; i++)
                    {
                        DataRow dataRow = schemaTable.Rows[i];
                        ///Cria o nome da coluna que é unico no data table
                        string columnName = (string)dataRow["ColumnName"]; //+ "<C" + i + "/>";
                        ///Adiciona a coluna para o data table
                        DataColumn column = new DataColumn(columnName, (Type)dataRow["DataType"]);
                        dataTable.Columns.Add(column);
                    }

                    dataSet.Tables.Add(dataTable);

                    ///Preenche o data table que foi criado
                    while (reader.Read())
                    {
                        DataRow dataRow = dataTable.NewRow();

                        for (int i = 0; i < reader.FieldCount; i++)
                            dataRow[i] = reader.GetValue(i);

                        dataTable.Rows.Add(dataRow);
                    }
                }
                else
                {
                    ///Nenhum registro encontrado
                    DataColumn column = new DataColumn("RowsAffected");
                    dataTable.Columns.Add(column);
                    dataSet.Tables.Add(dataTable);
                    DataRow dataRow = dataTable.NewRow();
                    dataRow[0] = reader.RecordsAffected;
                    dataTable.Rows.Add(dataRow);
                }
            }

            while (reader.NextResult());
            return dataSet;
        }

        /// <summary>
        /// Retorna o valor do parâmetro ou DBNull caso o objeto seja nulo
        /// </summary>
        /// <typeparam name="T">Tipo para o caso de parâmetros NULLABLE</typeparam>
        /// <param name="n">O parâmetro NULLABLE</param>
        /// <returns>O valor do parâmetro ou DBNull </returns>
        public static object ObterValorOuDBNull<T>(Nullable<T> n) where T : struct
        {
            if (n.HasValue)
                return n.Value;
            else
                return DBNull.Value;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            CloseConnection();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
