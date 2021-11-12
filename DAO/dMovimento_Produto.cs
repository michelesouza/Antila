using ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class dMovimento_Manual : dBaseDAO
    {
        public IList<eMovimento_Manual> Get(eMovimento_Manual obj)
        {
            IDataReader dr = null;
            IList<eMovimento_Manual> lista = new List<eMovimento_Manual>();
            SqlParameter[] param = null;

            try
            {
                cmd = new SqlCommand();
                param = new SqlParameter[1];
                lista = new List<eMovimento_Manual>();

                MontarParametro(0, param, ParameterDirection.Input, "@STA_STATUS", obj.Produto_Cosif.Produto.Sta_Produto, SqlDbType.VarChar);


                dr = ExecReader("USP_MOVIMENTO_MANUAIS_GET", cmd, param);

                if (dr != null)
                    while (dr.Read())
                        lista.Add(SetObject(dr));

                return lista;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { CloseConnection(); }
        }

        public eMovimento_Manual SetObject(IDataReader dr)
        {
            eMovimento_Manual obj = null;

            try
            {
                obj = new eMovimento_Manual();

                obj.Dat_Mes = GetInt32("DAT_MES", dr);
                obj.Dat_ano = GetInt32("DAT_ANO", dr);
                obj.Num_Lancamento = GetInt32("NUM_LANCAMENTO", dr);
                obj.Des_Descricao = GetString("DES_MOVIMENTO", dr);
                obj.Produto_Cosif.Produto.Cod_Produto = GetString("COD_PRODUTO", dr);
                obj.Valor = GetDecimal("VAL_VALOR", dr);
                obj.Produto_Cosif.Produto.Sta_Produto = GetString("STA_STATUS", dr);
                obj.Produto_Cosif.Produto.Des_produto = GetString("DES_PRODUTO", dr);
                obj.Produto_Cosif.Cod_Cosif = GetString("COD_COSIF", dr);

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Set(eMovimento_Manual obj)
        {
            SqlParameter[] param = null;
            try
            {
                cmd = new SqlCommand();
                param = new SqlParameter[7];

                MontarParametro(0, param, ParameterDirection.Input, "@DAT_MES", obj.Dat_Mes, SqlDbType.Int);
                MontarParametro(1, param, ParameterDirection.Input, "@DAT_ANO", obj.Dat_ano, SqlDbType.Int);
                MontarParametro(2, param, ParameterDirection.Input, "@COD_PRODUTO",obj.Produto_Cosif.Produto.Cod_Produto, SqlDbType.VarChar);
                MontarParametro(3, param, ParameterDirection.Input, "@COD_COSIF", obj.Produto_Cosif.Cod_Cosif, SqlDbType.Char);
                MontarParametro(4, param, ParameterDirection.Input, "@VAL_VALOR", obj.Valor, SqlDbType.Decimal);
                MontarParametro(5, param, ParameterDirection.Input, "@DES_MOVIMENTO", obj.Des_Descricao, SqlDbType.VarChar);
                MontarParametro(6, param, ParameterDirection.Input, "@COD_USUARIO", obj.Cod_Usuario, SqlDbType.VarChar);

                return ExecScalar("USP_MOVIMENTO_MANUAL_SET", cmd, param);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { CloseConnection(); }
        }
    }
}
